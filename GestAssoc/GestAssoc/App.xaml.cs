using System.Configuration;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace GestAssoc
{
	/// <summary>
	/// Logique d'interaction pour App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e) {
			base.OnStartup(e);

			// définition de la culture de l'application à partir de la configuration (ou d'une valeur par défaut)		
			try {
				var culture = CultureInfo.CreateSpecificCulture(ConfigurationManager.AppSettings.Get("UICulture"));
				Thread.CurrentThread.CurrentUICulture = culture;
			}
			catch (CultureNotFoundException) {
				Thread.CurrentThread.CurrentUICulture = CultureInfo.InstalledUICulture;
			}

			

			var bootstrapper = new Bootstrapper();
			bootstrapper.Run();
		}
	}
}
