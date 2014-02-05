using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GestAssoc.Model.Models.Mapping
{
    public class TrancheAgeMap : EntityTypeConfiguration<TrancheAge>
    {
        public TrancheAgeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("TrancheAges");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.AgeInf).HasColumnName("AgeInf");
            this.Property(t => t.AgeSup).HasColumnName("AgeSup");
        }
    }
}
