using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using GestAssoc.Model.Models.Mapping;

namespace GestAssoc.Model.Models
{
    public partial class GestAssocContext : DbContext
    {
        static GestAssocContext()
        {
            Database.SetInitializer<GestAssocContext>(null);
        }

        public GestAssocContext()
            : base("Name=GestAssocContext")
        {
        }

        public DbSet<Adherent> Adherents { get; set; }
        public DbSet<CampagneVerification> CampagneVerifications { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<DureeDeVie> DureeDeVies { get; set; }
        public DbSet<Equipement> Equipements { get; set; }
        public DbSet<Groupe> Groupes { get; set; }
        public DbSet<InfosClub> InfosClubs { get; set; }
        public DbSet<Inscription> Inscriptions { get; set; }
        public DbSet<Localisation> Localisations { get; set; }
        public DbSet<Marque> Marques { get; set; }
        public DbSet<Modele> Modeles { get; set; }
        public DbSet<Saison> Saisons { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<TrancheAge> TrancheAges { get; set; }
        public DbSet<Verification> Verifications { get; set; }
        public DbSet<Ville> Villes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AdherentMap());
            modelBuilder.Configurations.Add(new CampagneVerificationMap());
            modelBuilder.Configurations.Add(new CategorieMap());
            modelBuilder.Configurations.Add(new DureeDeVieMap());
            modelBuilder.Configurations.Add(new EquipementMap());
            modelBuilder.Configurations.Add(new GroupeMap());
            modelBuilder.Configurations.Add(new InfosClubMap());
            modelBuilder.Configurations.Add(new InscriptionMap());
            modelBuilder.Configurations.Add(new LocalisationMap());
            modelBuilder.Configurations.Add(new MarqueMap());
            modelBuilder.Configurations.Add(new ModeleMap());
            modelBuilder.Configurations.Add(new SaisonMap());
            modelBuilder.Configurations.Add(new SectionMap());
            modelBuilder.Configurations.Add(new TrancheAgeMap());
            modelBuilder.Configurations.Add(new VerificationMap());
            modelBuilder.Configurations.Add(new VilleMap());
        }
    }
}
