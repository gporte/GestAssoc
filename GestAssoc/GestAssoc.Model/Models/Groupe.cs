using System;
using System.Collections.Generic;

namespace GestAssoc.Model.Models
{
    public partial class Groupe
    {
        public Groupe()
        {
            this.Inscriptions = new List<Inscription>();
        }

        public System.Guid ID { get; set; }
        public string Libelle { get; set; }
        public int NbPlaces { get; set; }
        public string Commentaire { get; set; }
        public System.DateTime HeureDebut { get; set; }
        public System.DateTime HeureFin { get; set; }
        public int JourSemaine { get; set; }
        public Nullable<System.Guid> Saison_ID { get; set; }
        public virtual Saison Saison { get; set; }
        public virtual ICollection<Inscription> Inscriptions { get; set; }
    }
}
