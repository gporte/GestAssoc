using GestAssoc.Modules.GestionSaisons.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls.Ribbon;

namespace GestAssoc.Modules.GestionSaisons.Views
{
	/// <summary>
	/// Logique d'interaction pour GestionSaisonsMenuView.xaml
	/// </summary>
	public partial class GestionSaisonsMenuView : RibbonGroup, IRegionMemberLifetime
	{
		public GestionSaisonsMenuView() {
			InitializeComponent();
			this.DataContext = new GestionSaisonsMenuViewModel();
		}

		public bool KeepAlive {
			get { return true; }
		}
	}
}
