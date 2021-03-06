using GestAssoc.Model.Libelles;
using System;

namespace GestAssoc.Model.Models
{
	public partial class Inscription
	{
		public System.Guid ID { get; set; }
		public decimal Cotisation { get; set; }
		public System.DateTime DateCreation { get; set; }
		public System.DateTime DateModification { get; set; }
		public string Commentaire { get; set; }
		public bool CertificatMedicalRemis { get; set; }
		public string NumLicence { get; set; }
		public decimal MontantLicence { get; set; }
		public int StatutInscription { get; set; }
		public Nullable<System.Guid> Adherent_ID { get; set; }
		public Nullable<System.Guid> Groupe_ID { get; set; }
		public Nullable<System.Guid> Section_ID { get; set; }
		public virtual Adherent Adherent { get; set; }
		public virtual Groupe Groupe { get; set; }
		public virtual Section Section { get; set; }

		public string LibelleStatutInscription {
			get { return LibellesHelper.GetStatutInscriptionLibelle(this.StatutInscription); }
		}

		public override string ToString() {
			return string.Format("{0} - {1}", this.Groupe, this.Adherent);
		}
	}
}
