using System;
using System.Collections.Generic;

namespace GestAssoc.Model.Models
{
    public partial class Categorie
    {
        public Categorie()
        {
            this.Modeles = new List<Modele>();
        }

        public System.Guid ID { get; set; }
        public string Libelle { get; set; }
        public Nullable<System.Guid> DureeDeVie_ID { get; set; }
        public virtual DureeDeVie DureeDeVy { get; set; }
        public virtual ICollection<Modele> Modeles { get; set; }
    }
}
