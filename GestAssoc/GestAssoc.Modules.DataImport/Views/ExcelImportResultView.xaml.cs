using GestAssoc.Modules.DataImport.ImportModel;
using GestAssoc.Modules.DataImport.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace GestAssoc.Modules.DataImport.Views
{
	/// <summary>
	/// Logique d'interaction pour ExcelImportResultView.xaml
	/// </summary>
	public partial class ExcelImportResultView : UserControl, IRegionMemberLifetime, INavigationAware
	{
		public ExcelImportResultView() {
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
			var adherents = (IEnumerable<ImportLigne>)navigationContext.Parameters["Param"];

			if (adherents != null) {
				this.DataContext = new ExcelImportResultViewModel(adherents);
			}
			else {
				throw new Exception("Param invalide!");
			}
		}
	}
}
