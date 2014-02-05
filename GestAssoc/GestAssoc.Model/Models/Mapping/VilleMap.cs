using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GestAssoc.Model.Models.Mapping
{
    public class VilleMap : EntityTypeConfiguration<Ville>
    {
        public VilleMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Libelle)
                .HasMaxLength(4000);

            this.Property(t => t.CodePostal)
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("Villes");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Libelle).HasColumnName("Libelle");
            this.Property(t => t.CodePostal).HasColumnName("CodePostal");
        }
    }
}
