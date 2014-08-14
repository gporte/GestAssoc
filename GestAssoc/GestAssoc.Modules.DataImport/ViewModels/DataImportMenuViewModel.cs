using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.DataImport.Constantes;
using GestAssoc.Modules.DataImport.Properties;
using System.Windows.Input;

namespace GestAssoc.Modules.DataImport.ViewModels
{
	public class DataImportMenuViewModel : ViewModelBase
	{
		#region Commands
		public ICommand ShowImportExcelCsvCommand { get; set; }
		#endregion

		public DataImportMenuViewModel() {
			this.ShowImportExcelCsvCommand = new ShowViewCommand(ViewNames.ExcelCsvConfigImport.ToString());

			// trace
			NotificationHelper.WriteLog(Resources.Log_AffichageMenu);
		}
	}
}
