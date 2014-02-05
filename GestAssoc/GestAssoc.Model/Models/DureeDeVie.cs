using System;
using System.Collections.Generic;

namespace GestAssoc.Model.Models
{
    public partial class DureeDeVie
    {
        public DureeDeVie()
        {
            this.Categories = new List<Categorie>();
        }

        public System.Guid ID { get; set; }
        public string Libelle { get; set; }
        public int NbAnnees { get; set; }
        public int NbMois { get; set; }
        public virtual ICollection<Categorie> Categories { get; set; }
    }
}
