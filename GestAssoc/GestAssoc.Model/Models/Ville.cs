using System;
using System.Collections.Generic;

namespace GestAssoc.Model.Models
{
	public partial class Ville
	{
		public Ville()
		{
			this.Adherents = new List<Adherent>();
			this.InfosClubs = new List<InfosClub>();
		}

		public System.Guid ID { get; set; }
		public string Libelle { get; set; }
		public string CodePostal { get; set; }
		public virtual ICollection<Adherent> Adherents { get; set; }
		public virtual ICollection<InfosClub> InfosClubs { get; set; }

		public override string ToString() {
			return String.Format(
				"{0} - {1}", 
				this.CodePostal.PadLeft(5, ' '), 
				this.Libelle
			);
			;
		}

		public bool IsValid() {
			return !string.IsNullOrWhiteSpace(this.CodePostal) && !string.IsNullOrWhiteSpace(this.Libelle);
		}
	}
}
