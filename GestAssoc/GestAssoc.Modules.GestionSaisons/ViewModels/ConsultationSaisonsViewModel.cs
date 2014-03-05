using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionSaisons.Commands;
using GestAssoc.Modules.GestionSaisons.Constantes;
using GestAssoc.Modules.GestionSaisons.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionSaisons.ViewModels
{
	public class ConsultationSaisonsViewModel : ViewModelBase
	{
		private IGestionSaisonsServices _services;

		#region Items property
		private ICollectionView _items;
		public ObservableCollection<Saison> Items { get; private set; }
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

		#region Commands
		public ICommand EditSaisonCmd { get; set; }
		public ICommand DeleteSaisonCmd { get; set; }
		public ICommand AddSaisonCmd { get; set; }
		public ICommand ChangeSaisonCouranteCmd { get; set; }
		#endregion

		public ConsultationSaisonsViewModel() {
			this._services = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionSaisonsServices>();

			UIServices.SetBusyState();
			this.Items = new ObservableCollection<Saison>(this._services.GetAllSaisons());
			this._items = CollectionViewSource.GetDefaultView(this.Items);
			this._items.Filter = x => string.IsNullOrEmpty(this.ItemsFilter) ? true : ((Saison)x).ToString().ToUpper().Contains(this.ItemsFilter.ToUpper());

			this.EditSaisonCmd = new ShowViewCommandWithParameter(ViewNames.FormulaireSaison.ToString());
			this.DeleteSaisonCmd = new DeleteSaisonCommand();
			this.AddSaisonCmd = new ShowViewCommand(ViewNames.FormulaireSaison.ToString());
			this.ChangeSaisonCouranteCmd = new ChangeSaisonCouranteCommand();

			// trace
			NotificationHelper.WriteNotification("Affichage de la vue " + ViewNames.ConsultationSaisons.ToString());
		}
	}
}
