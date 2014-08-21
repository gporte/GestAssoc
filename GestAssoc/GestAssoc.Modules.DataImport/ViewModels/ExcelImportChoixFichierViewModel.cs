using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.DataImport.Constantes;
using GestAssoc.Modules.DataImport.Properties;
using Microsoft.Practices.Prism.Commands;
using System.IO;
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
			this.GoToConfigCmd = new DelegateCommand(this.ExecuteGoToConfigCmd);

			// trace
			NotificationHelper.WriteLog(Resources.Log_AffichageVue + ViewNames.ExcelImportChoixFichier.ToString());
		}

		private void ExecuteGoToConfigCmd() {
			if (File.Exists(this.FilePath)) {
				new ShowViewCommandWithParameter(ViewNames.ExcelImportConfig.ToString()).Execute(this.FilePath);				
			}
			else {
				NotificationHelper.ShowUserNotification(Resources.Err_FichierNonTrouve);
			}
		}
	}
}
