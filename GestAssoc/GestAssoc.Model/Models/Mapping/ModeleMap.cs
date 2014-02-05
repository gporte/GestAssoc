using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GestAssoc.Model.Models.Mapping
{
    public class ModeleMap : EntityTypeConfiguration<Modele>
    {
        public ModeleMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Nom)
                .HasMaxLength(4000);

            this.Property(t => t.Couleur1)
                .HasMaxLength(4000);

            this.Property(t => t.Couleur2)
                .HasMaxLength(4000);

            this.Property(t => t.Couleur3)
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("Modeles");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Nom).HasColumnName("Nom");
            this.Property(t => t.Couleur1).HasColumnName("Couleur1");
            this.Property(t => t.Couleur2).HasColumnName("Couleur2");
            this.Property(t => t.Couleur3).HasColumnName("Couleur3");
            this.Property(t => t.Categorie_ID).HasColumnName("Categorie_ID");
            this.Property(t => t.Marque_ID).HasColumnName("Marque_ID");

            // Relationships
            this.HasOptional(t => t.Category)
                .WithMany(t => t.Modeles)
                .HasForeignKey(d => d.Categorie_ID);
            this.HasOptional(t => t.Marque)
                .WithMany(t => t.Modeles)
                .HasForeignKey(d => d.Marque_ID);

        }
    }
}
