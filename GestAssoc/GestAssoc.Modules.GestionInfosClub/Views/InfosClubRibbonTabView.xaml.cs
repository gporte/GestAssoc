using GestAssoc.Modules.GestionInfosClub.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls.Ribbon;

namespace GestAssoc.Modules.GestionInfosClub.Views
{
	/// <summary>
	/// Logique d'interaction pour InfosClubRibbonTabView.xaml
	/// </summary>
	public partial class InfosClubRibbonTabView : RibbonTab, IRegionMemberLifetime
	{
		public InfosClubRibbonTabView() {
			InitializeComponent();
			this.DataContext = new InfosClubRibbonTabViewModel();
		}

		public bool KeepAlive {
			get { return true; }
		}
	}
}
