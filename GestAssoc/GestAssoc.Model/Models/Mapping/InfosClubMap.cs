using System.Data.Entity.ModelConfiguration;

namespace GestAssoc.Model.Models.Mapping
{
	public class InfosClubMap : EntityTypeConfiguration<InfosClub>
	{
		public InfosClubMap()
		{
			// Primary Key
			this.HasKey(t => t.ID);

			// Properties
			this.Property(t => t.Nom)
				.HasMaxLength(4000);

			this.Property(t => t.Numero)
				.HasMaxLength(4000);

			this.Property(t => t.Siren)
				.HasMaxLength(4000);

			this.Property(t => t.NIC)
				.HasMaxLength(4000);

			this.Property(t => t.Adresse)
				.HasMaxLength(4000);

			this.Property(t => t.Telephone)
				.HasMaxLength(4000);

			this.Property(t => t.Mail)
				.HasMaxLength(4000);

			this.Property(t => t.SiteWeb)
				.HasMaxLength(4000);

			this.Property(t => t.NumAPS)
				.HasMaxLength(4000);

			this.Property(t => t.NumFederation)
				.HasMaxLength(4000);

			this.Property(t => t.Ville)
				.HasMaxLength(4000);

			this.Property(t => t.CodePostal)
				.HasMaxLength(4000);

			// Table & Column Mappings
			this.ToTable("InfosClubs");
			this.Property(t => t.ID).HasColumnName("ID");
			this.Property(t => t.Nom).HasColumnName("Nom");
			this.Property(t => t.Numero).HasColumnName("Numero");
			this.Property(t => t.Siren).HasColumnName("Siren");
			this.Property(t => t.NIC).HasColumnName("NIC");
			this.Property(t => t.Adresse).HasColumnName("Adresse");
			this.Property(t => t.Telephone).HasColumnName("Telephone");
			this.Property(t => t.Mail).HasColumnName("Mail");
			this.Property(t => t.SiteWeb).HasColumnName("SiteWeb");
			this.Property(t => t.NumAPS).HasColumnName("NumAPS");
			this.Property(t => t.NumFederation).HasColumnName("NumFederation");
			this.Property(t => t.Ville).HasColumnName("Ville");
			this.Property(t => t.CodePostal).HasColumnName("CodePostal");
		}
	}
}
