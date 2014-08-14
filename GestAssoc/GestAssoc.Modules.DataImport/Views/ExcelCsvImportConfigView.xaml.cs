using GestAssoc.Modules.DataImport.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls;

namespace GestAssoc.Modules.DataImport.Views
{
	/// <summary>
	/// Logique d'interaction pour ExcelCsvImportConfig.xaml
	/// </summary>
	public partial class ExcelCsvImportConfigView : UserControl, IRegionMemberLifetime
	{
		public ExcelCsvImportConfigView() {
			InitializeComponent();
			this.DataContext = new ExcelCsvImportConfigViewModel();
		}

		public bool KeepAlive {
			get { return true; }
		}
	}
}
