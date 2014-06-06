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

			var bootstrapper = new Bootstrapper();
			bootstrapper.Run();
		}
	}
}
