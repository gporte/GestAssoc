using GestAssoc.Common.Event;
using GestAssoc.ViewModels;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System.Windows.Controls.Ribbon;
using Xceed.Wpf.Toolkit;

namespace GestAssoc.Views
{
	/// <summary>
	/// Logique d'interaction pour MainWindow.xaml
	/// </summary>
	public partial class ShellWindow : RibbonWindow
	{
		public ShellWindow(ShellWindowViewModel vm) {
			InitializeComponent();
			this.DataContext = vm;

			var aggregator = ServiceLocator
							.Current.GetInstance<IUnityContainer>()
							.Resolve<IEventAggregator>();

			aggregator.GetEvent<ShowErrorEvent>().Subscribe(this.ShowError);
		}

		private void ShowError(string errorMsg) {
			MessageBox.Show(errorMsg, Properties.Resources.Titre_Erreur);
		}
	}
}
