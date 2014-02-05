using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GestAssoc.Model.Models.Mapping
{
    public class SaisonMap : EntityTypeConfiguration<Saison>
    {
        public SaisonMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Saisons");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.EstSaisonCourante).HasColumnName("EstSaisonCourante");
            this.Property(t => t.AnneeDebut).HasColumnName("AnneeDebut");
            this.Property(t => t.AnneeFin).HasColumnName("AnneeFin");
        }
    }
}
