using GestAssoc.Modules.GestionGroupes.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls.Ribbon;

namespace GestAssoc.Modules.GestionGroupes.Views
{
	/// <summary>
	/// Logique d'interaction pour GestionGroupesMenuView.xaml
	/// </summary>
	public partial class GestionGroupesMenuView : RibbonGroup, IRegionMemberLifetime
	{
		public GestionGroupesMenuView() {
			InitializeComponent();
			this.DataContext = new GestionGroupesMenuViewModel();
		}

		public bool KeepAlive {
			get { return true; }
		}
	}
}
