using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GestAssoc.Model.Models.Mapping
{
    public class EquipementMap : EntityTypeConfiguration<Equipement>
    {
        public EquipementMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Numero)
                .HasMaxLength(4000);

            this.Property(t => t.Commentaire)
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("Equipements");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Numero).HasColumnName("Numero");
            this.Property(t => t.DateAchat).HasColumnName("DateAchat");
            this.Property(t => t.DateCreation).HasColumnName("DateCreation");
            this.Property(t => t.DateModification).HasColumnName("DateModification");
            this.Property(t => t.Commentaire).HasColumnName("Commentaire");
            this.Property(t => t.Modele_ID).HasColumnName("Modele_ID");
            this.Property(t => t.Localisation_ID).HasColumnName("Localisation_ID");

            // Relationships
            this.HasOptional(t => t.Localisation)
                .WithMany(t => t.Equipements)
                .HasForeignKey(d => d.Localisation_ID);
            this.HasOptional(t => t.Modele)
                .WithMany(t => t.Equipements)
                .HasForeignKey(d => d.Modele_ID);

        }
    }
}
