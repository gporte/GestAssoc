using GestAssoc.Modules.GestionVilles.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls.Ribbon;

namespace GestAssoc.Modules.GestionVilles.Views
{
	/// <summary>
	/// Logique d'interaction pour GestionVillesRibbonTabView.xaml
	/// </summary>
	public partial class GestionVillesRibbonTabView : RibbonTab, IRegionMemberLifetime
	{
		public GestionVillesRibbonTabView() {
			InitializeComponent();
			this.DataContext = new GestionVillesRibbonTabViewModel();
		}

		public bool KeepAlive {
			get { return true; }
		}
	}
}
