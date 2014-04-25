using GestAssoc.Model.Libelles;
using System;
using System.Collections.Generic;

namespace GestAssoc.Model.Models
{
	public partial class Adherent
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Adherent()
		{
			this.Inscriptions = new List<Inscription>();
		}

		public System.Guid ID { get; set; }
		public string Nom { get; set; }
		public string Prenom { get; set; }
		public System.DateTime DateNaissance { get; set; }
		public System.DateTime DateCreation { get; set; }
		public System.DateTime DateModification { get; set; }
		public string Commentaire { get; set; }
		public string Adresse { get; set; }
		public string Telephone1 { get; set; }
		public string Telephone2 { get; set; }
		public string Telephone3 { get; set; }
		public string Mail1 { get; set; }
		public string Mail2 { get; set; }
		public string Mail3 { get; set; }
		public int Sexe { get; set; }
		public Nullable<System.Guid> Ville_ID { get; set; }
		public virtual Ville Ville { get; set; }
		public virtual ICollection<Inscription> Inscriptions { get; set; }

		public override string ToString() {
			return string.Format("{0} {1}", this.Nom, this.Prenom);
		}

		public string LibelleSexe {
			get { return LibellesHelper.GetSexeLibelle(this.Sexe); }
		}

		public int Age {
			get { return this.CalculerAge(); }
		}

		/// <summary>
		/// Calcule l'age de l'adherent à partir de sa date de naissance
		/// </summary>
		/// <returns>Age de l'adhérent</returns>
		private int CalculerAge() {
			int num = DateTime.Now.Year - this.DateNaissance.Year;
			DateTime time = new DateTime(DateTime.Now.Year, this.DateNaissance.Month, this.DateNaissance.Day);
			if (time > DateTime.Now) {
				num--;
			}
			return num;
		}
	}
}
