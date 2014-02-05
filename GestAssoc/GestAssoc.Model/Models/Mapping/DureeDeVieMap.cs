using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GestAssoc.Model.Models.Mapping
{
    public class DureeDeVieMap : EntityTypeConfiguration<DureeDeVie>
    {
        public DureeDeVieMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Libelle)
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("DureeDeVies");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Libelle).HasColumnName("Libelle");
            this.Property(t => t.NbAnnees).HasColumnName("NbAnnees");
            this.Property(t => t.NbMois).HasColumnName("NbMois");
        }
    }
}
