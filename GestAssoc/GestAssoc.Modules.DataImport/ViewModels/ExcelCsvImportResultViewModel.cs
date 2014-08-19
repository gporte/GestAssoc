using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.DataImport.Constantes;
using GestAssoc.Modules.DataImport.ImportModel;
using GestAssoc.Modules.DataImport.Properties;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GestAssoc.Modules.DataImport.ViewModels
{
	public class ExcelCsvImportResultViewModel : ViewModelBase
	{
		#region Adherents property
		private ObservableCollection<ImportAdherent> _adherents;
		public ObservableCollection<ImportAdherent> Adherents {
			get { return this._adherents; }
			set {
				this.SetProperty(ref this._adherents, value);
			}
		}
		#endregion

		public ExcelCsvImportResultViewModel(IEnumerable<ImportAdherent> adherents) {
			this.Adherents = new ObservableCollection<ImportAdherent>(adherents);

			// trace
			NotificationHelper.WriteLog(Resources.Log_AffichageVue + ViewNames.ExcelCsvImportResult.ToString());
		}
	}
}
