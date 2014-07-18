using GestAssoc.Modules.GestionAdhesions.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls.Ribbon;

namespace GestAssoc.Modules.GestionAdhesions.Views
{
	/// <summary>
	/// Logique d'interaction pour GestionAdherentsMenuView.xaml
	/// </summary>
	public partial class GestionAdherentsMenuView : RibbonGroup, IRegionMemberLifetime
	{
		public GestionAdherentsMenuView() {
			InitializeComponent();
			this.DataContext = new GestionAdherentsMenuViewModel();
		}

		public bool KeepAlive {
			get { return true; }
		}
	}
}
