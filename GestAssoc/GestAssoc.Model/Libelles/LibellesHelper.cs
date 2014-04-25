using System.Reflection;
using System.Resources;

namespace GestAssoc.Model.Libelles
{
	public static class LibellesHelper
	{
		public static string GetJourSemaineLibelle(int jourSemaine) {
			var rm = new ResourceManager(
				"GestAssoc.Model.Libelles.ResLibelles", 
				Assembly.GetExecutingAssembly()
			);

			return rm.GetString("JS" + jourSemaine.ToString()) ?? ResLibelles.LIBELLE_ABSENT;
		}

		public static string GetSexeLibelle(int sexe) {
			var rm = new ResourceManager(
				"GestAssoc.Model.Libelles.ResLibelles",
				Assembly.GetExecutingAssembly()
			);

			return rm.GetString("SX" + sexe.ToString()) ?? ResLibelles.LIBELLE_ABSENT;
		}

		public static string GetStatutInscriptionLibelle(int statut) {
			var rm = new ResourceManager(
				"GestAssoc.Model.Libelles.ResLibelles",
				Assembly.GetExecutingAssembly()
			);

			return rm.GetString("STI" + statut.ToString()) ?? ResLibelles.LIBELLE_ABSENT;
		}
	}

}