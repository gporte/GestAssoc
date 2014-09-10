using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
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
using System.Linq;
using System.Windows.Input;

namespace GestAssoc.Modules.DataImport.ViewModels
{
	public class ExcelImportConfigViewModel : ViewModelBase
	{
		private IExcelCsvImportService _services;

		#region FilePath property
		private string _filePath;
		public string FilePath {
			get { return this._filePath; }
			set {
				this.SetProperty(ref this._filePath, value);
			}
		}
		#endregion

		#region ColumnsMapping property
		private ObservableCollection<ColumnMapping> _columnsMapping;
		public ObservableCollection<ColumnMapping> ColumnsMapping {
			get { return this._columnsMapping; }
			set {
				this.SetProperty(ref this._columnsMapping, value);
			}
		}
		#endregion

		#region ColumnsList property
		private ObservableCollection<string> _columnList;
		public ObservableCollection<string> ColumnsList {
			get { return this._columnList; }
			set {
				this.SetProperty(ref this._columnList, value);
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
		public ICommand GoBackCmd { get; set; }
		public ICommand ReadFileCmd { get; set; }
		public ICommand ChangeWorksheetCmd { get; set; }
		#endregion

		public ExcelImportConfigViewModel(string filePath) {
			this.FilePath = filePath;

			// enregistrement et initialisation des services
			ServiceLocator.Current.GetInstance<IUnityContainer>().RegisterType<IExcelCsvImportService, ExcelCsvImportService>();
			this._services = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IExcelCsvImportService>();

			this.WorkSheetNames = new ObservableCollection<string>(this._services.GetSheetNames(this.FilePath));
			this.SelectedSheetName = this.WorkSheetNames.First();
			this.PopulateColumnList(this.SelectedSheetName);
			this.ColumnsMapping = new ObservableCollection<ColumnMapping>(this._services.InitColMapping(this.ColumnsList.ToList()));

			this.GoBackCmd = new ShowViewCommandWithParameter(ViewNames.ExcelImportChoixFichier.ToString());
			this.ReadFileCmd = new DelegateCommand(this.ExecuteReadFileCmd);
			this.ChangeWorksheetCmd = new DelegateCommand<string>(this.PopulateColumnList);
			

			// trace
			NotificationHelper.WriteLog(Resources.Log_AffichageVue + ViewNames.ExcelImportConfig.ToString());
		}

		private void ExecuteReadFileCmd() {
			UIServices.SetBusyState();
			var adh = this._services.ReadImportLignes(this.FilePath, this.SelectedSheetName, new List<ColumnMapping>(this.ColumnsMapping));

			new ShowViewCommandWithParameter(ViewNames.ExcelImportResult.ToString()).Execute(adh);

		}

		private void PopulateColumnList(string selectedWorksheet) {
			this.ColumnsList = new ObservableCollection<string>(this._services.GetColumnsNames(this.FilePath, this.SelectedSheetName));
			this.ColumnsMapping = new ObservableCollection<ColumnMapping>(this._services.InitColMapping(this.ColumnsList.ToList()));
		}
	}
}
