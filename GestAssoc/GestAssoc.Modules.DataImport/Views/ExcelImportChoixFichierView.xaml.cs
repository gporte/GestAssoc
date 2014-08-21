using GestAssoc.Modules.DataImport.ViewModels;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Win32;
using System;
using System.Windows.Controls;

namespace GestAssoc.Modules.DataImport.Views
{
	/// <summary>
	/// Logique d'interaction pour ExcelImportChoixFichierView.xaml
	/// </summary>
	public partial class ExcelImportChoixFichierView : UserControl, IRegionMemberLifetime, INavigationAware
	{
		public ExcelImportChoixFichierView() {
			InitializeComponent();
		}

		public bool KeepAlive {
			get { return true; }
		}

		private void Button_Click(object sender, System.Windows.RoutedEventArgs e) {
			var dialog = new OpenFileDialog();
			dialog.Filter = "Excel (*.xls, *.xlsx)|*.xls;*.xlsx";

			if (dialog.ShowDialog().Value) {
				this.tbxFilePath.Text = dialog.FileName;
			}
		}

		public bool IsNavigationTarget(NavigationContext navigationContext) {
			return false;
		}

		public void OnNavigatedFrom(NavigationContext navigationContext) {

		}

		public void OnNavigatedTo(NavigationContext navigationContext) {
			var param = navigationContext.Parameters["Param"];

			var filePath = (param != null) ? param.ToString() : string.Empty;
			this.DataContext = new ExcelImportChoixFichierViewModel(filePath);
		}
	}
}
