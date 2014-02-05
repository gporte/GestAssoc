using System;
using System.Collections.Generic;

namespace GestAssoc.Model.Models
{
    public partial class Section
    {
        public Section()
        {
            this.Inscriptions = new List<Inscription>();
        }

        public System.Guid ID { get; set; }
        public string Libelle { get; set; }
        public bool EstDefaut { get; set; }
        public virtual ICollection<Inscription> Inscriptions { get; set; }
    }
}
