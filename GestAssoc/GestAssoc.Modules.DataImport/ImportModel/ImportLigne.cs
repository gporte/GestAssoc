using System;

namespace GestAssoc.Modules.DataImport.ImportModel
{
	public class ImportLigne
	{
		public string Nom { get; set; }
		public string Prenom { get; set; }
		public string DateNaissance { get; set; }
		
		public string Adresse { get; set; }
		public string Ville { get; set; }
		public string CodePostal { get; set; }
		
		public string Tel1 { get; set; }
		public string Tel2 { get; set; }
		public string Tel3 { get; set; }
		
		public string Mail1 { get; set; }
		public string Mail2 { get; set; }
		public string Mail3 { get; set; }

		public string Groupe { get; set; }
		public string CertificatMedical { get; set; }
		public string Cotisation { get; set; }
		public string CommentaireInscription { get; set; }

		public bool AdherentExiste { get; set; }
		public bool InscriptionExiste { get; set; }
		public bool VilleExiste { get; set; }
		public bool GroupeExiste { get; set; }
	}
}
