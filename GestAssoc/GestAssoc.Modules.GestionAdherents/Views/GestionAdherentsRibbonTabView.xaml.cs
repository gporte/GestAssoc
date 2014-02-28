using GestAssoc.Modules.GestionAdherents.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls.Ribbon;

namespace GestAssoc.Modules.GestionAdherents.Views
{
	/// <summary>
	/// Logique d'interaction pour GestionAdherentsRibbonTabView.xaml
	/// </summary>
	public partial class GestionAdherentsRibbonTabView : RibbonTab, IRegionMemberLifetime
	{
		public GestionAdherentsRibbonTabView() {
			InitializeComponent();
			this.DataContext = new GestionAdherentsRibbonTabViewModel();
		}

		public bool KeepAlive {
			get { return true; }
		}
	}
}
