using System;
using System.Collections.Generic;

namespace GestAssoc.Model.Models
{
    public partial class Marque
    {
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Marque()
        {
            this.Modeles = new List<Modele>();
        }

        public System.Guid ID { get; set; }
        public string Libelle { get; set; }
        public virtual ICollection<Modele> Modeles { get; set; }
    }
}
