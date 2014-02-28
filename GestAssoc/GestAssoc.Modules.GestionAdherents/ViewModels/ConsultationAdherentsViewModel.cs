using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Constantes;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionAdherents.Commands;
using GestAssoc.Modules.GestionAdherents.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionAdherents.ViewModels
{
	public class ConsultationAdherentsViewModel : ViewModelBase
	{
		private IGestionAdherentsServices _services;

		#region Items property
		private ICollectionView _items;
		public ObservableCollection<Adherent> Items { get; private set; }
		#endregion

		#region ItemsFilter property
		private string _itemsFilter;
		public string ItemsFilter {
			get { return this._itemsFilter; }
			set {
				if (this._itemsFilter != value) {
					this._itemsFilter = value;
					this._items.Refresh();
					this.RaisePropertyChangedEvent("ItemsFilter");
				}
			}
		}
		#endregion

		public ICommand EditAdherentCmd { get; set; }
		public ICommand DeleteAdherentCmd { get; set; }
		public ICommand AddAdherentCmd { get; set; }

		public ConsultationAdherentsViewModel() {
			this._services = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionAdherentsServices>();

			UIServices.SetBusyState();
			this.Items = new ObservableCollection<Adherent>(this._services.GetAllAdherents());
			this._items = CollectionViewSource.GetDefaultView(this.Items);
			this._items.Filter = x => string.IsNullOrEmpty(this.ItemsFilter) ? true : ((Groupe)x).ToString().ToUpper().Contains(this.ItemsFilter.ToUpper());

			this.EditAdherentCmd = new ShowViewCommandWithParameter(ViewNames.FormulaireAdherent);
			this.DeleteAdherentCmd = new DeleteAdherentCommand();
			this.AddAdherentCmd = new ShowViewCommand(ViewNames.FormulaireAdherent);

			// trace
			NotificationHelper.WriteNotification("Affichage de la vue " + ViewNames.FormulaireAdherent);
		}
	}
}
