using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GestAssoc.Model.Models.Mapping
{
    public class VerificationMap : EntityTypeConfiguration<Verification>
    {
        public VerificationMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Commentaire)
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("Verifications");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Commentaire).HasColumnName("Commentaire");
            this.Property(t => t.StatutVerification).HasColumnName("StatutVerification");
            this.Property(t => t.CampagneVerification_ID).HasColumnName("CampagneVerification_ID");
            this.Property(t => t.Equipement_ID).HasColumnName("Equipement_ID");

            // Relationships
            this.HasOptional(t => t.CampagneVerification)
                .WithMany(t => t.Verifications)
                .HasForeignKey(d => d.CampagneVerification_ID);
            this.HasOptional(t => t.Equipement)
                .WithMany(t => t.Verifications)
                .HasForeignKey(d => d.Equipement_ID);

        }
    }
}
