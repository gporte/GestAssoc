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

namespace GestAssoc.Modules.DataImport.ViewModels
{
	public class ExcelCsvImportConfigViewModel : ViewModelBase
	{
		private IExcelCsvImportService _services;
		
		#region FilePathProperty
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

		#region WorkSheetNames property
		private ObservableCollection<string> _worksheetNames;
		public ObservableCollection<string> WorkSheetNames {
			get { return this._worksheetNames; }
			set {
				this.SetProperty(ref this._worksheetNames, value);
			}
		}
		#endregion

		#region Commands
		public ICommand ReadFileCmd { get; set; }
		#endregion

		public ExcelCsvImportConfigViewModel() {
			// enregistrement et initialisation des services
			ServiceLocator.Current.GetInstance<IUnityContainer>().RegisterType<IExcelCsvImportService, ExcelCsvImportService>();
			this._services = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IExcelCsvImportService>();

			this.ColumnsMapping = new ObservableCollection<ColumnMapping>(this._services.InitColMapping());

			this.ReadFileCmd = new DelegateCommand(this.ExecuteReadFileCmd);

			// trace
			NotificationHelper.WriteLog(Resources.Log_AffichageVue + ViewNames.ExcelCsvConfigImport.ToString());
		}

		private void ExecuteReadFileCmd() {
			var filePath = @"C:\Users\gp.HARDIS\Downloads\INSCRIPTION 2014.xls";

			var adh = this._services.ReadAdherents(filePath, "", new List<ColumnMapping>(this.ColumnsMapping));
		}
	}
}
