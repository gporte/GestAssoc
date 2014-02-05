using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GestAssoc.Model.Models.Mapping
{
    public class InscriptionMap : EntityTypeConfiguration<Inscription>
    {
        public InscriptionMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Commentaire)
                .HasMaxLength(4000);

            this.Property(t => t.NumLicence)
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("Inscriptions");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Cotisation).HasColumnName("Cotisation");
            this.Property(t => t.DateCreation).HasColumnName("DateCreation");
            this.Property(t => t.DateModification).HasColumnName("DateModification");
            this.Property(t => t.Commentaire).HasColumnName("Commentaire");
            this.Property(t => t.CertificatMedicalRemis).HasColumnName("CertificatMedicalRemis");
            this.Property(t => t.NumLicence).HasColumnName("NumLicence");
            this.Property(t => t.MontantLicence).HasColumnName("MontantLicence");
            this.Property(t => t.StatutInscription).HasColumnName("StatutInscription");
            this.Property(t => t.Adherent_ID).HasColumnName("Adherent_ID");
            this.Property(t => t.Groupe_ID).HasColumnName("Groupe_ID");
            this.Property(t => t.Section_ID).HasColumnName("Section_ID");

            // Relationships
            this.HasOptional(t => t.Adherent)
                .WithMany(t => t.Inscriptions)
                .HasForeignKey(d => d.Adherent_ID);
            this.HasOptional(t => t.Groupe)
                .WithMany(t => t.Inscriptions)
                .HasForeignKey(d => d.Groupe_ID);
            this.HasOptional(t => t.Section)
                .WithMany(t => t.Inscriptions)
                .HasForeignKey(d => d.Section_ID);

        }
    }
}
