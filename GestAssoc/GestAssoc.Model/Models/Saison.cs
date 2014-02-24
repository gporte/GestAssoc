using System.Collections.Generic;

namespace GestAssoc.Model.Models
{
	public partial class Saison
	{
		public Saison()
		{
			this.Groupes = new List<Groupe>();
		}

		public System.Guid ID { get; set; }
		public bool EstSaisonCourante { get; set; }
		public int AnneeDebut { get; set; }
		public int AnneeFin { get; set; }
		public virtual ICollection<Groupe> Groupes { get; set; }

		public override string ToString() {
			return string.Format("{0} - {1}", this.AnneeDebut.ToString(), this.AnneeFin.ToString());
		}
	}
}
