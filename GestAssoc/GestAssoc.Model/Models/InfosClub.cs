using System;
using System.Collections.Generic;

namespace GestAssoc.Model.Models
{
	public partial class InfosClub
	{
		public System.Guid ID { get; set; }
		public string Nom { get; set; }
		public string Numero { get; set; }
		public string Siren { get; set; }
		public string NIC { get; set; }
		public string Adresse { get; set; }
		public string Telephone { get; set; }
		public string Mail { get; set; }
		public string SiteWeb { get; set; }
		public string NumAPS { get; set; }
		public string NumFederation { get; set; }
		public Nullable<System.Guid> Ville_ID { get; set; }
		public virtual Ville Ville { get; set; }

		public string Siret {
			get { return string.Format("{0} - {1}", this.Siren, this.NIC); }
		}
	}
}
