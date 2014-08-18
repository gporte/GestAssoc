using GestAssoc.Modules.DataImport.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Windows.Controls;

namespace GestAssoc.Modules.DataImport.Views
{
	/// <summary>
	/// Logique d'interaction pour ExcelCsvImportConfig.xaml
	/// </summary>
	public partial class ExcelCsvImportConfigView : UserControl, IRegionMemberLifetime, INavigationAware
	{
		public ExcelCsvImportConfigView() {
			InitializeComponent();
		}

		public bool KeepAlive {
			get { return true; }
		}

		public bool IsNavigationTarget(NavigationContext navigationContext) {
			return false;
		}

		public void OnNavigatedFrom(NavigationContext navigationContext) {

		}

		public void OnNavigatedTo(NavigationContext navigationContext) {
			var filePath = navigationContext.Parameters["Param"].ToString();

			if (filePath != null) {
				this.DataContext = new ExcelCsvImportConfigViewModel(filePath);
			}
			else {
				throw new Exception("Fichier non fourni!");
			}
		}
	}
}
