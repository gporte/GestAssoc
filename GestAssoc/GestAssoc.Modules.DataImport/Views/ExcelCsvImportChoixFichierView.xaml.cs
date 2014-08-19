using GestAssoc.Modules.DataImport.ViewModels;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Win32;
using System.Windows.Controls;

namespace GestAssoc.Modules.DataImport.Views
{
	/// <summary>
	/// Logique d'interaction pour ExcelCsvImportChoixFichierView.xaml
	/// </summary>
	public partial class ExcelCsvImportChoixFichierView : UserControl, IRegionMemberLifetime
	{
		public ExcelCsvImportChoixFichierView() {
			InitializeComponent();
			this.DataContext = new ExcelCsvImportChoixFichierViewModel();
		}

		public bool KeepAlive {
			get { return true; }
		}

		private void Button_Click(object sender, System.Windows.RoutedEventArgs e) {
			var dialog = new OpenFileDialog();
			dialog.Filter = "Excel (*.xls, *.xlsx)|*.xls;*.xlsx|CSV (*.csv)|*.csv";

			if (dialog.ShowDialog().Value) {
				this.tbxFilePath.Text = dialog.FileName;
			}
		}
	}
}
