using System;
using System.Collections.Generic;

namespace GestAssoc.Model.Models
{
    public partial class Equipement
    {
        public Equipement()
        {
            this.Verifications = new List<Verification>();
        }

        public System.Guid ID { get; set; }
        public string Numero { get; set; }
        public Nullable<System.DateTime> DateAchat { get; set; }
        public System.DateTime DateCreation { get; set; }
        public System.DateTime DateModification { get; set; }
        public string Commentaire { get; set; }
        public Nullable<System.Guid> Modele_ID { get; set; }
        public Nullable<System.Guid> Localisation_ID { get; set; }
        public virtual Localisation Localisation { get; set; }
        public virtual Modele Modele { get; set; }
        public virtual ICollection<Verification> Verifications { get; set; }
    }
}
