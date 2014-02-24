using GestAssoc.Modules.GestionInfosClub.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls;

namespace GestAssoc.Modules.GestionInfosClub.Views
{
	/// <summary>
	/// Logique d'interaction pour InfosClubView.xaml
	/// </summary>
	public partial class InfosClubView : UserControl, IRegionMemberLifetime
	{
		public InfosClubView() {
			InitializeComponent();
			this.DataContext = new InfosClubViewModel();
		}

		public bool KeepAlive {
			get { return false; }
		}
	}
}
