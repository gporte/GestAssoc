using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GestAssoc.Model.Models.Mapping
{
    public class AdherentMap : EntityTypeConfiguration<Adherent>
    {
        public AdherentMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Nom)
                .HasMaxLength(4000);

            this.Property(t => t.Prenom)
                .HasMaxLength(4000);

            this.Property(t => t.Commentaire)
                .HasMaxLength(4000);

            this.Property(t => t.Adresse)
                .HasMaxLength(4000);

            this.Property(t => t.Telephone1)
                .HasMaxLength(4000);

            this.Property(t => t.Telephone2)
                .HasMaxLength(4000);

            this.Property(t => t.Telephone3)
                .HasMaxLength(4000);

            this.Property(t => t.Mail1)
                .HasMaxLength(4000);

            this.Property(t => t.Mail2)
                .HasMaxLength(4000);

            this.Property(t => t.Mail3)
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("Adherents");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Nom).HasColumnName("Nom");
            this.Property(t => t.Prenom).HasColumnName("Prenom");
            this.Property(t => t.DateNaissance).HasColumnName("DateNaissance");
            this.Property(t => t.DateCreation).HasColumnName("DateCreation");
            this.Property(t => t.DateModification).HasColumnName("DateModification");
            this.Property(t => t.Commentaire).HasColumnName("Commentaire");
            this.Property(t => t.Adresse).HasColumnName("Adresse");
            this.Property(t => t.Telephone1).HasColumnName("Telephone1");
            this.Property(t => t.Telephone2).HasColumnName("Telephone2");
            this.Property(t => t.Telephone3).HasColumnName("Telephone3");
            this.Property(t => t.Mail1).HasColumnName("Mail1");
            this.Property(t => t.Mail2).HasColumnName("Mail2");
            this.Property(t => t.Mail3).HasColumnName("Mail3");
            this.Property(t => t.Sexe).HasColumnName("Sexe");
            this.Property(t => t.Ville_ID).HasColumnName("Ville_ID");

            // Relationships
            this.HasOptional(t => t.Ville)
                .WithMany(t => t.Adherents)
                .HasForeignKey(d => d.Ville_ID);

        }
    }
}
