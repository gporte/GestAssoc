using System;
using System.Collections.Generic;

namespace GestAssoc.Model.Models
{
    public partial class CampagneVerification
    {
        public CampagneVerification()
        {
            this.Verifications = new List<Verification>();
        }

        public System.Guid ID { get; set; }
        public System.DateTime Date { get; set; }
        public string Responsable { get; set; }
        public bool EstValidee { get; set; }
        public virtual ICollection<Verification> Verifications { get; set; }
    }
}
