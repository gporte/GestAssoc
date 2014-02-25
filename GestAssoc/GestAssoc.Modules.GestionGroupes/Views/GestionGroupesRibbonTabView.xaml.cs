using GestAssoc.Modules.GestionGroupes.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls.Ribbon;

namespace GestAssoc.Modules.GestionGroupes.Views
{
	/// <summary>
	/// Logique d'interaction pour GestionGroupesRibbonTabView.xaml
	/// </summary>
	public partial class GestionGroupesRibbonTabView : RibbonTab, IRegionMemberLifetime
	{
		public GestionGroupesRibbonTabView() {
			InitializeComponent();
			this.DataContext = new GestionGroupesRibbonTabViewModel();
		}

		public bool KeepAlive {
			get { return true; }
		}
	}
}
