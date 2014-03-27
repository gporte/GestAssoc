using GestAssoc.Modules.GestionInscriptions.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls.Ribbon;

namespace GestAssoc.Modules.GestionInscriptions.Views
{
	/// <summary>
	/// Logique d'interaction pour GestionInscriptionsMenuView.xaml
	/// </summary>
	public partial class GestionInscriptionsMenuView : RibbonGroup, IRegionMemberLifetime
	{
		public GestionInscriptionsMenuView() {
			InitializeComponent();
			this.DataContext = new GestionInscriptionsMenuViewModel();
		}

		public bool KeepAlive {
			get { return true; }
		}
	}
}
