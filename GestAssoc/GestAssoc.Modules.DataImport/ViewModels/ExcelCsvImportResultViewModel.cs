using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.DataImport.Constantes;
using GestAssoc.Modules.DataImport.Properties;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GestAssoc.Modules.DataImport.ViewModels
{
	public class ExcelCsvImportResultViewModel : ViewModelBase
	{
		#region Adherents property
		private ObservableCollection<Adherent> _adherents;
		public ObservableCollection<Adherent> Adherents {
			get { return this._adherents; }
			set {
				this.SetProperty(ref this._adherents, value);
			}
		}
		#endregion

		public ExcelCsvImportResultViewModel(IEnumerable<Adherent> adherents) {
			this.Adherents = new ObservableCollection<Adherent>(adherents);

			// trace
			NotificationHelper.WriteLog(Resources.Log_AffichageVue + ViewNames.ExcelCsvImportResult.ToString());
		}
	}
}
