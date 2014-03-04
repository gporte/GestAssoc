using GestAssoc.Modules.GestionInfosClub.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls.Ribbon;

namespace GestAssoc.Modules.GestionInfosClub.Views
{
	/// <summary>
	/// Logique d'interaction pour InfosClubMenuView.xaml
	/// </summary>
	public partial class InfosClubMenuView : RibbonGroup, IRegionMemberLifetime
	{
		public InfosClubMenuView() {
			InitializeComponent();
			this.DataContext = new InfosClubMenuViewModel();
		}

		public bool KeepAlive {
			get { return true; }
		}
	}
}
