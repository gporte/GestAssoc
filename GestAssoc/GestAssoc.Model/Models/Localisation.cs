using System;
using System.Collections.Generic;

namespace GestAssoc.Model.Models
{
    public partial class Localisation
    {
        public Localisation()
        {
            this.Equipements = new List<Equipement>();
        }

        public System.Guid ID { get; set; }
        public string Libelle { get; set; }
        public virtual ICollection<Equipement> Equipements { get; set; }
    }
}
