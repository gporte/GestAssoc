using System;

namespace GestAssoc.Modules.DataImport.ImportModel
{
	public class ImportAdherent
	{
		public string Nom { get; set; }
		public string Prenom { get; set; }
		public string DateNaissance { get; set; }
		public string Adresse { get; set; }
		public string Ville { get; set; }
		public string CodePostal { get; set; }
		public bool Existe { get; set; }
	}
}
