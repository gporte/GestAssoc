using Microsoft.Practices.Prism.Regions;
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
		}

		public bool KeepAlive {
			get { return true; }
		}
	}
}
