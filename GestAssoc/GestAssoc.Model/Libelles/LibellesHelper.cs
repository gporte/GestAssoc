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
	}

}