using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Constantes;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionVilles.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionVilles.ViewModels
{
	public class ConsultationVillesViewModel : ViewModelBase
	{
		private IGestionVillesServices _services;
		
		#region Items property
		private ObservableCollection<Ville> _items;
		public ObservableCollection<Ville> Items {
			get { return this._items; }
			set {
				if (this._items != value) {
					this._items = value;
					this.RaisePropertyChangedEvent("Items");
				}
			}
		}
		#endregion

		public ICommand EditVilleCmd { get; set; }

		public ConsultationVillesViewModel() {
			this._services = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionVillesServices>();

			this.Items = this._services.GetAllVilles();
			this.EditVilleCmd = new ShowViewCommandWithParameter(ViewNames.FormulaireVille);
		}
	}
}
