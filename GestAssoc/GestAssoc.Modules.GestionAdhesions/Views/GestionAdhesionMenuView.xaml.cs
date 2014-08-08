using GestAssoc.Modules.GestionAdhesions.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls.Ribbon;

namespace GestAssoc.Modules.GestionAdhesions.Views
{
	/// <summary>
	/// Logique d'interaction pour GestionAdhesionMenuView.xaml
	/// </summary>
	public partial class GestionAdhesionMenuView : RibbonTab, IRegionMemberLifetime
	{
		public GestionAdhesionMenuView()
		{
			InitializeComponent();
			this.DataContext = new GestionAdhesionMenuViewModel();
		}

		public bool KeepAlive
		{
			get { return true; }
		}
	}
}
