using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.DataImport.Constantes;
using GestAssoc.Modules.DataImport.ImportModel;
using GestAssoc.Modules.DataImport.Util;
using LinqToExcel;
using MinimumEditDistance;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestAssoc.Modules.DataImport.Services
{
	public class ExcelCsvImportService : IExcelCsvImportService
	{
		public IEnumerable<ImportLigne> ReadImportLignes(string filePath, string sheetName, List<ColumnMapping> colMapping) {
			var excel = new ExcelQueryFactory(filePath);

			excel.AddMapping<ImportLigne>(x => x.Nom, colMapping.FirstOrDefault(y => y.DataName == ColumnName.Nom).ColumnHeader);
			excel.AddMapping<ImportLigne>(x => x.Prenom, colMapping.FirstOrDefault(y => y.DataName == ColumnName.Prenom).ColumnHeader);
			excel.AddMapping<ImportLigne>(x => x.DateNaissance, colMapping.FirstOrDefault(y => y.DataName == ColumnName.DateNaissance).ColumnHeader);

			excel.AddMapping<ImportLigne>(x => x.Adresse, colMapping.FirstOrDefault(y => y.DataName == ColumnName.Adresse).ColumnHeader);
			excel.AddMapping<ImportLigne>(x => x.Ville, colMapping.FirstOrDefault(y => y.DataName == ColumnName.Ville).ColumnHeader);
			excel.AddMapping<ImportLigne>(x => x.CodePostal, colMapping.FirstOrDefault(y => y.DataName == ColumnName.CodePostal).ColumnHeader);

			excel.AddMapping<ImportLigne>(x => x.Tel1, colMapping.FirstOrDefault(y => y.DataName == ColumnName.Tel1).ColumnHeader);
			excel.AddMapping<ImportLigne>(x => x.Tel2, colMapping.FirstOrDefault(y => y.DataName == ColumnName.Tel2).ColumnHeader);
			excel.AddMapping<ImportLigne>(x => x.Tel3, colMapping.FirstOrDefault(y => y.DataName == ColumnName.Tel3).ColumnHeader);

			excel.AddMapping<ImportLigne>(x => x.Mail1, colMapping.FirstOrDefault(y => y.DataName == ColumnName.Mail1).ColumnHeader);
			excel.AddMapping<ImportLigne>(x => x.Mail2, colMapping.FirstOrDefault(y => y.DataName == ColumnName.Mail2).ColumnHeader);
			excel.AddMapping<ImportLigne>(x => x.Mail3, colMapping.FirstOrDefault(y => y.DataName == ColumnName.Mail3).ColumnHeader);
			
			excel.AddMapping<ImportLigne>(x => x.Groupe, colMapping.FirstOrDefault(y => y.DataName == ColumnName.Groupe).ColumnHeader);
			excel.AddMapping<ImportLigne>(x => x.CertificatMedical, colMapping.FirstOrDefault(y => y.DataName == ColumnName.CertificatMedical).ColumnHeader);
			excel.AddMapping<ImportLigne>(x => x.Cotisation, colMapping.FirstOrDefault(y => y.DataName == ColumnName.Cotisation).ColumnHeader);
			excel.AddMapping<ImportLigne>(x => x.CommentaireInscription, colMapping.FirstOrDefault(y => y.DataName == ColumnName.CommentaireInscription).ColumnHeader);

			var ws = excel.Worksheet<ImportLigne>(sheetName);

			var adhList = ws.ToList();
			var ctx = new GestAssocContext();

			foreach (var adh in adhList.Where(x => x.Nom != null)) {
				adh.Nom = (adh.Nom ?? string.Empty).ToUpperInvariant();
				adh.Ville = (adh.Ville ?? string.Empty).ToUpperInvariant();

				adh.AdherentExiste = ctx.Adherents.Count(x => x.Nom == adh.Nom && x.Prenom == adh.Prenom) > 0;

				if (adh.AdherentExiste) {
					adh.InscriptionExiste = ctx.Inscriptions.Where(x => x.Groupe.Saison.EstSaisonCourante).Count(x => x.Adherent.Nom == adh.Nom && x.Adherent.Prenom == adh.Prenom) > 0;
				}
			}

			return new List<ImportLigne>(adhList);
		}

		public IEnumerable<ColumnMapping> InitColMapping(IEnumerable<string> columnsList) {
			return new List<ColumnMapping> 
			{
				new ColumnMapping(ColumnName.Nom, SearchBestColumnName(columnsList, ColumnName.Nom.ToString())),
				new ColumnMapping(ColumnName.Prenom, SearchBestColumnName(columnsList, ColumnName.Prenom.ToString())),
				new ColumnMapping(ColumnName.DateNaissance, SearchBestColumnName(columnsList, ColumnName.DateNaissance.ToString())),

				new ColumnMapping(ColumnName.Adresse, SearchBestColumnName(columnsList, ColumnName.Adresse.ToString())),
				new ColumnMapping(ColumnName.CodePostal, SearchBestColumnName(columnsList, ColumnName.CodePostal.ToString())),
				new ColumnMapping(ColumnName.Ville, SearchBestColumnName(columnsList, ColumnName.Ville.ToString())),

				new ColumnMapping(ColumnName.Tel1, SearchBestColumnName(columnsList, ColumnName.Tel1.ToString())),
				new ColumnMapping(ColumnName.Tel2, SearchBestColumnName(columnsList, ColumnName.Tel2.ToString())),
				new ColumnMapping(ColumnName.Tel3, SearchBestColumnName(columnsList, ColumnName.Tel3.ToString())),

				new ColumnMapping(ColumnName.Mail1, SearchBestColumnName(columnsList, ColumnName.Mail1.ToString())),
				new ColumnMapping(ColumnName.Mail2, SearchBestColumnName(columnsList, ColumnName.Mail2.ToString())),
				new ColumnMapping(ColumnName.Mail3, SearchBestColumnName(columnsList, ColumnName.Mail3.ToString())),

				new ColumnMapping(ColumnName.Groupe, SearchBestColumnName(columnsList, ColumnName.Groupe.ToString())),
				new ColumnMapping(ColumnName.CertificatMedical, SearchBestColumnName(columnsList, ColumnName.CertificatMedical.ToString())),
				new ColumnMapping(ColumnName.Cotisation, SearchBestColumnName(columnsList, ColumnName.Cotisation.ToString())),
				new ColumnMapping(ColumnName.CommentaireInscription, SearchBestColumnName(columnsList, ColumnName.CommentaireInscription.ToString()))
			};
		}


		public IEnumerable<string> GetSheetNames(string filePath) {
			var excel = new ExcelQueryFactory(filePath);
			return excel.GetWorksheetNames();
		}

		public IEnumerable<string> GetColumnsNames(string filePath, string worksheetName) {
			var excel = new ExcelQueryFactory(filePath);
			return excel.GetColumnNames(worksheetName);
		}

		private static string SearchBestColumnName(IEnumerable<string> columnList, string dataName) {
			var result = string.Empty;

			foreach (var column in columnList) {
				if (Levenshtein.CalculateDistance(column, dataName, 1) < Levenshtein.CalculateDistance(result, dataName, 1)) {
					result = column;
				}
			}

			return result;
		}

		public void InsertImportLignes(IEnumerable<ImportLigne> lignes) {
			var ctx = new GestAssocContext();

			try {
				foreach (var ligne in lignes.Where(x => x.Nom != null)) {
					var trace = string.Format("Traitement de la ligne {0} {1}", ligne.Nom, ligne.Prenom);

					this.LigneImportToInscriptionId(ligne, ctx);
				}
			}
			catch (Exception ex) {
				NotificationHelper.ShowError(ex);
				throw;
			}

			ctx.SaveChanges();
		}

		private Guid LigneImportToInscriptionId(ImportLigne ligne, GestAssocContext ctx) {
			var result = Guid.Empty;

			var adhId = this.LigneImportToAdherentId(ligne, ctx);
			var grpId = this.LigneImportToGroupeId(ligne, ctx);

			var certificat = false;
			bool.TryParse(ligne.CertificatMedical, out certificat);

			var cotisation = decimal.Zero;
			decimal.TryParse(ligne.Cotisation, out cotisation);

			var section = ctx.Sections.FirstOrDefault(x => x.EstDefaut);


			var inscription = ctx.Inscriptions.FirstOrDefault(x => x.Groupe.Saison.EstSaisonCourante && x.Adherent.ID == adhId);

			if (inscription != null) {
				result = inscription.ID;
				NotificationHelper.WriteLog(string.Format("L'inscription {0} existe déjà avec l'ID {1} => on l'utilise.", inscription.ToString(), inscription.ID));
			}
			else { // création de l'inscription
				inscription = new Inscription()
				{
					ID = Guid.NewGuid(),
					
					Adherent_ID = adhId,
					Adherent = ctx.Adherents.Find(adhId),

					Groupe_ID = grpId,
					Groupe = ctx.Groupes.Find(grpId),

					CertificatMedicalRemis = certificat,
					Cotisation = cotisation,

					Commentaire = ligne.CommentaireInscription,

					Section_ID = section.ID,
					Section = section,

					NumLicence = string.Empty,

					StatutInscription = 0,

					DateCreation = DateTime.Now,
					DateModification = DateTime.Now					
				};

				ctx.Inscriptions.Add(inscription);
				//ctx.SaveChanges();

				result = inscription.ID;

				NotificationHelper.WriteLog(string.Format("L'inscription {0} a été créée avec l'ID {1}.", inscription.ToString(), inscription.ID));
			}

			return result;
		}

		private Guid LigneImportToGroupeId(ImportLigne ligne, GestAssocContext ctx) {
			var result = Guid.Empty;

			// valeurs par défaut si non renseigné
			var valueLibelle = (string.IsNullOrWhiteSpace(ligne.Groupe)) ? "INCONNU" : ligne.Groupe;

			var groupe = ctx.Groupes.FirstOrDefault(x => x.Saison.EstSaisonCourante && x.Libelle == valueLibelle);

			if (groupe != null) {
				result = groupe.ID;

				NotificationHelper.WriteLog(string.Format("Le groupe {0} existe déjà avec l'ID {1} => on l'utilise.", groupe.ToString(), groupe.ID));
			}
			else { // création du groupe
				groupe = new Groupe() 
				{
					ID = Guid.NewGuid(),
					Libelle = valueLibelle,
					HeureDebut = DefaultValueHelper.DateTimeSQLMinValue,
					HeureFin = DefaultValueHelper.DateTimeSQLMinValue
				};

				ctx.Groupes.Add(groupe);
				//ctx.SaveChanges();

				result = groupe.ID;

				NotificationHelper.WriteLog(string.Format("Le groupe {0} a été créé avec l'ID {1}.", groupe.ToString(), groupe.ID));
			}

			return result;
		}

		private Guid LigneImportToAdherentId(ImportLigne ligne, GestAssocContext ctx) {
			var result = Guid.Empty;

			var adh = ctx.Adherents.FirstOrDefault(x => x.Nom == ligne.Nom && x.Prenom == ligne.Prenom);

			if(adh != null) {
				result = adh.ID;
				NotificationHelper.WriteLog(string.Format("L'adhérent {0} existe déjà avec l'ID {1} => on l'utilise.", adh.ToString(), adh.ID));
			}
			else { // création de l'adhérent
				var naissance = DateTime.Today;
				DateTime.TryParse(ligne.DateNaissance, out naissance);

				if (naissance < DefaultValueHelper.DateTimeSQLMinValue) {
					naissance = DefaultValueHelper.DateTimeSQLMinValue;
				}

				var villeId = this.LigneImportToVilleId(ligne, ctx);

				adh = new Adherent()
				{
					ID = Guid.NewGuid(),
					Nom = ligne.Nom,
					Prenom = ligne.Prenom,
					DateNaissance = naissance,
					
					Adresse = ligne.Adresse,
					Ville_ID = villeId,
					Ville = ctx.Villes.Find(villeId),

					Telephone1 = ligne.Tel1,
					Telephone2 = ligne.Tel2,
					Telephone3 = ligne.Tel3,

					Mail1 = ligne.Mail1,
					Mail2 = ligne.Mail2,
					Mail3 = ligne.Mail3,

					DateCreation = DateTime.Now,
					DateModification = DateTime.Now
				};

				ctx.Adherents.Add(adh);
				//ctx.SaveChanges();

				result = adh.ID;

				NotificationHelper.WriteLog(string.Format("L'adhérent {0} a été créé avec l'ID {1}.", adh.ToString(), adh.ID));
			}

			return result;
		}

		private Guid LigneImportToVilleId(ImportLigne ligne, GestAssocContext ctx) {
			var result = Guid.Empty;

			// valeurs par défaut si non renseigné
			var valueVille = (string.IsNullOrWhiteSpace(ligne.Ville)) ? "INCONNU" : ligne.Ville;
			var valueCodePostal = (string.IsNullOrWhiteSpace(ligne.CodePostal)) ? "00000" : ligne.CodePostal;

			var ville = ctx.Villes.FirstOrDefault(x => x.CodePostal == valueCodePostal && x.Libelle == valueVille);

			if(ville != null) {
				result = ville.ID;
				NotificationHelper.WriteLog(string.Format("La ville {0} existe déjà avec l'ID {1} => on l'utilise.", ville.ToString(), ville.ID));
			}
			else { // création de la ville
				ville = new Ville() 
				{
					ID = Guid.NewGuid(),
					Libelle = valueVille,
					CodePostal = valueCodePostal
				};

				ctx.Villes.Add(ville);
				//ctx.SaveChanges();

				result = ville.ID;

				NotificationHelper.WriteLog(string.Format("La ville {0} a été créée avec l'ID {1}.", ville.ToString(), ville.ID));
			}

			return result;
		}
	}
}
