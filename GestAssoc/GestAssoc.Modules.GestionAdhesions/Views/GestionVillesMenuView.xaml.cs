using GestAssoc.Modules.GestionAdhesions.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls.Ribbon;

namespace GestAssoc.Modules.GestionAdhesions.Views
{
	/// <summary>
	/// Logique d'interaction pour GestionVillesMenuView.xaml
	/// </summary>
	public partial class GestionVillesMenuView : RibbonGroup, IRegionMemberLifetime
	{
		public GestionVillesMenuView() {
			InitializeComponent();
			this.DataContext = new GestionVillesMenuViewModel();
		}

		public bool KeepAlive {
			get { return true; }
		}
	}
}
