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
		private ObservableCollection<ImportAdherent> _importDatas;
		public ObservableCollection<ImportAdherent> ImportDatas {
			get { return this._importDatas; }
			set {
				this.SetProperty(ref this._importDatas, value);
			}
		}
		#endregion

		public ExcelImportResultViewModel(IEnumerable<ImportAdherent> adherents) {
			this.ImportDatas = new ObservableCollection<ImportAdherent>(adherents);

			// trace
			NotificationHelper.WriteLog(Resources.Log_AffichageVue + ViewNames.ExcelImportResult.ToString());
		}
	}
}
