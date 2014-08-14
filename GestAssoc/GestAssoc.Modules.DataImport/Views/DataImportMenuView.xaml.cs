using GestAssoc.Modules.DataImport.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls.Ribbon;

namespace GestAssoc.Modules.DataImport.Views
{
	/// <summary>
	/// Logique d'interaction pour DataImportMenuView.xaml
	/// </summary>
	public partial class DataImportMenuView : RibbonTab, IRegionMemberLifetime
	{
		public DataImportMenuView() {
			InitializeComponent();
			this.DataContext = new DataImportMenuViewModel();
		}

		public bool KeepAlive {
			get { return true; }
		}
	}
}
