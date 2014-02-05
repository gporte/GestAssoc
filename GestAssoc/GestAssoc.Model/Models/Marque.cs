using System;
using System.Collections.Generic;

namespace GestAssoc.Model.Models
{
    public partial class Marque
    {
        public Marque()
        {
            this.Modeles = new List<Modele>();
        }

        public System.Guid ID { get; set; }
        public string Libelle { get; set; }
        public virtual ICollection<Modele> Modeles { get; set; }
    }
}
