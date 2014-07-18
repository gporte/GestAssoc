using GestAssoc.Modules.GestionAdhesions.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls.Ribbon;

namespace GestAssoc.Modules.GestionAdhesions.Views
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
