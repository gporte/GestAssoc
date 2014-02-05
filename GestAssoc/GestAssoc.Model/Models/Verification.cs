using System;
using System.Collections.Generic;

namespace GestAssoc.Model.Models
{
    public partial class Verification
    {
        public System.Guid ID { get; set; }
        public string Commentaire { get; set; }
        public int StatutVerification { get; set; }
        public Nullable<System.Guid> CampagneVerification_ID { get; set; }
        public Nullable<System.Guid> Equipement_ID { get; set; }
        public virtual CampagneVerification CampagneVerification { get; set; }
        public virtual Equipement Equipement { get; set; }
    }
}
