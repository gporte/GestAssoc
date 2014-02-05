using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GestAssoc.Model.Models.Mapping
{
    public class GroupeMap : EntityTypeConfiguration<Groupe>
    {
        public GroupeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Libelle)
                .HasMaxLength(4000);

            this.Property(t => t.Commentaire)
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("Groupes");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Libelle).HasColumnName("Libelle");
            this.Property(t => t.NbPlaces).HasColumnName("NbPlaces");
            this.Property(t => t.Commentaire).HasColumnName("Commentaire");
            this.Property(t => t.HeureDebut).HasColumnName("HeureDebut");
            this.Property(t => t.HeureFin).HasColumnName("HeureFin");
            this.Property(t => t.JourSemaine).HasColumnName("JourSemaine");
            this.Property(t => t.Saison_ID).HasColumnName("Saison_ID");

            // Relationships
            this.HasOptional(t => t.Saison)
                .WithMany(t => t.Groupes)
                .HasForeignKey(d => d.Saison_ID);

        }
    }
}
