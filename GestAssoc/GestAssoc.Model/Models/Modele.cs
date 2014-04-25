using System;
using System.Collections.Generic;

namespace GestAssoc.Model.Models
{
    public partial class Modele
    {
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Modele()
        {
            this.Equipements = new List<Equipement>();
        }

        public System.Guid ID { get; set; }
        public string Nom { get; set; }
        public string Couleur1 { get; set; }
        public string Couleur2 { get; set; }
        public string Couleur3 { get; set; }
        public Nullable<System.Guid> Categorie_ID { get; set; }
        public Nullable<System.Guid> Marque_ID { get; set; }
        public virtual Categorie Category { get; set; }
        public virtual ICollection<Equipement> Equipements { get; set; }
        public virtual Marque Marque { get; set; }
    }
}
