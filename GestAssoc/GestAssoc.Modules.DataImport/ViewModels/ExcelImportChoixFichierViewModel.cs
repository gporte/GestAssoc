using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.DataImport.Constantes;
using GestAssoc.Modules.DataImport.Properties;
using System.Windows.Input;

namespace GestAssoc.Modules.DataImport.ViewModels
{
	public class ExcelImportChoixFichierViewModel : ViewModelBase
	{
		#region FilePathProperty
		private string _filePath;
		public string FilePath {
			get { return this._filePath; }
			set {
				this.SetProperty(ref this._filePath, value);
			}
		}
		#endregion

		#region Commands
		public ICommand ShowOpenFileDialogCmd { get; set; }
		public ICommand GoToConfigCmd { get; set; }
		#endregion

		public ExcelImportChoixFichierViewModel(string filepath) {
			this.FilePath = filepath;
			this.GoToConfigCmd = new ShowViewCommandWithParameter(ViewNames.ExcelImportConfig.ToString());

			// trace
			NotificationHelper.WriteLog(Resources.Log_AffichageVue + ViewNames.ExcelImportChoixFichier.ToString());
		}
	}
}
