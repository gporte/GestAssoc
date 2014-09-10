using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.DataImport.Constantes;
using GestAssoc.Modules.DataImport.ImportModel;
using GestAssoc.Modules.DataImport.Properties;
using GestAssoc.Modules.DataImport.Services;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GestAssoc.Modules.DataImport.ViewModels
{
	public class ExcelImportResultViewModel : ViewModelBase
	{
		private IExcelCsvImportService _services;

		#region Adherents property
		private ObservableCollection<ImportLigne> _importDatas;
		public ObservableCollection<ImportLigne> ImportDatas {
			get { return this._importDatas; }
			set {
				this.SetProperty(ref this._importDatas, value);
			}
		}
		#endregion

		#region Commands
		public ICommand InsertDatasCmd { get; set; }
		#endregion

		public ExcelImportResultViewModel(IEnumerable<ImportLigne> adherents) {
			// enregistrement et initialisation des services
			ServiceLocator.Current.GetInstance<IUnityContainer>().RegisterType<IExcelCsvImportService, ExcelCsvImportService>();
			this._services = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IExcelCsvImportService>();
			
			this.ImportDatas = new ObservableCollection<ImportLigne>(adherents);

			this.InsertDatasCmd = new DelegateCommand(this.ExecuteInsertDatasCmd, this.CanExecuteInsertDatasCmd);

			// trace
			NotificationHelper.WriteLog(Resources.Log_AffichageVue + ViewNames.ExcelImportResult.ToString());
		}

		private bool CanExecuteInsertDatasCmd() {
			return this.ImportDatas != null && this.ImportDatas.Count > 0;
		}

		private void ExecuteInsertDatasCmd() {
			UIServices.SetBusyState();
			this._services.InsertImportLignes(this._importDatas);

			new ShowViewCommand(ViewNames.ExcelImportChoixFichier.ToString());
		}

	}
}
