using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GestAssoc.Model.Models.Mapping
{
    public class LocalisationMap : EntityTypeConfiguration<Localisation>
    {
        public LocalisationMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Libelle)
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("Localisations");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Libelle).HasColumnName("Libelle");
        }
    }
}
