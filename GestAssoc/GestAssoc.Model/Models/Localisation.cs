using System;
using System.Collections.Generic;

namespace GestAssoc.Model.Models
{
    public partial class Localisation
    {
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Localisation()
        {
            this.Equipements = new List<Equipement>();
        }

        public System.Guid ID { get; set; }
        public string Libelle { get; set; }
        public virtual ICollection<Equipement> Equipements { get; set; }
    }
}
