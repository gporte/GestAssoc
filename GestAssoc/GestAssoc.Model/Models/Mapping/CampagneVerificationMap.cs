using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GestAssoc.Model.Models.Mapping
{
    public class CampagneVerificationMap : EntityTypeConfiguration<CampagneVerification>
    {
        public CampagneVerificationMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Responsable)
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("CampagneVerifications");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.Responsable).HasColumnName("Responsable");
            this.Property(t => t.EstValidee).HasColumnName("EstValidee");
        }
    }
}
