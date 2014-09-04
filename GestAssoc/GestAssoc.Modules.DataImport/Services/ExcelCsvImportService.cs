using GestAssoc.Model.Models;
using GestAssoc.Modules.DataImport.Constantes;
using GestAssoc.Modules.DataImport.ImportModel;
using GestAssoc.Modules.DataImport.Util;
using LinqToExcel;
using MinimumEditDistance;
using System.Collections.Generic;
using System.Linq;

namespace GestAssoc.Modules.DataImport.Services
{
	public class ExcelCsvImportService : IExcelCsvImportService
	{
		public IEnumerable<ImportLigne> ReadAdherents(string filePath, string sheetName, List<ColumnMapping> colMapping) {
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

			foreach (var adh in adhList) {
				adh.Nom = (adh.Nom ?? string.Empty).ToUpperInvariant();
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
	}
}
