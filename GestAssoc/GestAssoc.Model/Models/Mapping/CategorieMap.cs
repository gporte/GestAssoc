using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GestAssoc.Model.Models.Mapping
{
    public class CategorieMap : EntityTypeConfiguration<Categorie>
    {
        public CategorieMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Libelle)
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("Categories");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Libelle).HasColumnName("Libelle");
            this.Property(t => t.DureeDeVie_ID).HasColumnName("DureeDeVie_ID");

            // Relationships
            this.HasOptional(t => t.DureeDeVy)
                .WithMany(t => t.Categories)
                .HasForeignKey(d => d.DureeDeVie_ID);

        }
    }
}
