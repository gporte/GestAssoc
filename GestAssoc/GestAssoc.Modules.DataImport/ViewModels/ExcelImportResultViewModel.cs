using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.DataImport.Constantes;
using GestAssoc.Modules.DataImport.ImportModel;
using GestAssoc.Modules.DataImport.Properties;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GestAssoc.Modules.DataImport.ViewModels
{
	public class ExcelImportResultViewModel : ViewModelBase
	{
		#region Adherents property
		private ObservableCollection<ImportLigne> _importDatas;
		public ObservableCollection<ImportLigne> ImportDatas {
			get { return this._importDatas; }
			set {
				this.SetProperty(ref this._importDatas, value);
			}
		}
		#endregion

		public ExcelImportResultViewModel(IEnumerable<ImportLigne> adherents) {
			this.ImportDatas = new ObservableCollection<ImportLigne>(adherents);

			// trace
			NotificationHelper.WriteLog(Resources.Log_AffichageVue + ViewNames.ExcelImportResult.ToString());
		}
	}
}
