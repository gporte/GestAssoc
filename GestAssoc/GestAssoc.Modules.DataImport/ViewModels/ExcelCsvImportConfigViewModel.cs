using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.DataImport.Constantes;
using GestAssoc.Modules.DataImport.Properties;
using GestAssoc.Modules.DataImport.Services;
using GestAssoc.Modules.DataImport.Util;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using GestAssoc.Common.Commands;

namespace GestAssoc.Modules.DataImport.ViewModels
{
	public class ExcelCsvImportConfigViewModel : ViewModelBase
	{
		private IExcelCsvImportService _services;
		private string _filePath;
		
		#region ColumnsMapping property
		private ObservableCollection<ColumnMapping> _columnsMapping;
		public ObservableCollection<ColumnMapping> ColumnsMapping {
			get { return this._columnsMapping; }
			set {
				this.SetProperty(ref this._columnsMapping, value);
			}
		}
		#endregion

		#region WorkSheetNames property
		private ObservableCollection<string> _worksheetNames;
		public ObservableCollection<string> WorkSheetNames {
			get { return this._worksheetNames; }
			set {
				this.SetProperty(ref this._worksheetNames, value);
			}
		}
		#endregion

		#region SelectedSheetName property
		private string _selectedSheetName;
		public string SelectedSheetName {
			get { return this._selectedSheetName; }
			set {
				this.SetProperty(ref this._selectedSheetName, value);
			}
		}
		#endregion

		#region Commands
		public ICommand ReadFileCmd { get; set; }
		#endregion

		public ExcelCsvImportConfigViewModel(string filePath) {
			this._filePath = filePath;

			// enregistrement et initialisation des services
			ServiceLocator.Current.GetInstance<IUnityContainer>().RegisterType<IExcelCsvImportService, ExcelCsvImportService>();
			this._services = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IExcelCsvImportService>();

			this.ColumnsMapping = new ObservableCollection<ColumnMapping>(this._services.InitColMapping());
			this.WorkSheetNames = new ObservableCollection<string>(this._services.GetSheetNames(this._filePath));
			this.SelectedSheetName = this.WorkSheetNames.First();

			this.ReadFileCmd = new DelegateCommand(this.ExecuteReadFileCmd);

			// trace
			NotificationHelper.WriteLog(Resources.Log_AffichageVue + ViewNames.ExcelCsvImportConfig.ToString());
		}

		private void ExecuteReadFileCmd() {
			var adh = this._services.ReadAdherents(this._filePath, this.SelectedSheetName, new List<ColumnMapping>(this.ColumnsMapping));

			if (adh != null && adh.Count() > 0) {
				var cmd = new ShowViewCommandWithParameter(ViewNames.ExcelCsvImportResult.ToString());
				cmd.Execute(adh);
			}
			else {
				NotificationHelper.ShowUserNotification("Impossible d'importer les données.");
			}
		}
	}
}
