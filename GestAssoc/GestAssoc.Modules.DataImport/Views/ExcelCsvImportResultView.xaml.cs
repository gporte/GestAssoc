using GestAssoc.Model.Models;
using GestAssoc.Modules.DataImport.ViewModels;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace GestAssoc.Modules.DataImport.Views
{
	/// <summary>
	/// Logique d'interaction pour ExcelCsvImportResultView.xaml
	/// </summary>
	public partial class ExcelCsvImportResultView : UserControl, IRegionMemberLifetime, INavigationAware
	{
		public ExcelCsvImportResultView() {
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
			var adherents = (IEnumerable<Adherent>)navigationContext.Parameters["Param"];

			if (adherents != null) {
				this.DataContext = new ExcelCsvImportResultViewModel(adherents);
			}
			else {
				throw new Exception("Param invalide!");
			}
		}
	}
}
