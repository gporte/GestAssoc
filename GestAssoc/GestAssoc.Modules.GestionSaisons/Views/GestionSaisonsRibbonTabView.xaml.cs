using GestAssoc.Modules.GestionSaisons.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls.Ribbon;

namespace GestAssoc.Modules.GestionSaisons.Views
{
	/// <summary>
	/// Logique d'interaction pour GestionSaisonsRibbonTabView.xaml
	/// </summary>
	public partial class GestionSaisonsRibbonTabView : RibbonTab, IRegionMemberLifetime
	{
		public GestionSaisonsRibbonTabView() {
			InitializeComponent();
			this.DataContext = new GestionSaisonsRibbonTabViewModel();
		}

		public bool KeepAlive {
			get { return true; }
		}
	}
}
