using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionInscriptions.Commands;
using GestAssoc.Modules.GestionInscriptions.Constantes;
using GestAssoc.Modules.GestionInscriptions.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionInscriptions.ViewModels
{
	public class ConsultationInscriptionsViewModel : ViewModelBase
	{
		private IGestionInscriptionsServices _services;

		#region Items property
		private ICollectionView _items;
		public ObservableCollection<Inscription> Items { get; private set; }
		#endregion

		#region ItemsFilter property
		private string _itemsFilter;
		public string ItemsFilter {
			get { return this._itemsFilter; }
			set {
				this._items.Refresh();
				this.SetProperty(ref this._itemsFilter, value);
			}
		}
		#endregion

		public ICommand EditInscriptionCmd { get; set; }
		public ICommand DeleteInscriptionCmd { get; set; }
		public ICommand AddInscriptionCmd { get; set; }

		public ConsultationInscriptionsViewModel() {
			// enregistrement et initialisation des services
			ServiceLocator.Current.GetInstance<IUnityContainer>().RegisterType<IGestionInscriptionsServices, GestionInscriptionServices>();

			this._services = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionInscriptionsServices>();

			this.LoadItems();

			this.EditInscriptionCmd = new ShowViewCommandWithParameter(ViewNames.FormulaireInscription.ToString());
			this.DeleteInscriptionCmd = new DeleteInscriptionCommand(this.LoadItems);
			this.AddInscriptionCmd = new ShowViewCommand(ViewNames.FormulaireInscription.ToString());

			// trace
			NotificationHelper.WriteLog(Properties.Resources.Log_AffichageVue + ViewNames.ConsultationInscriptions.ToString());
		}

		private void LoadItems() {
			try {
				UIServices.SetBusyState();
				this.Items = new ObservableCollection<Inscription>(this._services.GetAllInscriptions());
				this._items = CollectionViewSource.GetDefaultView(this.Items);
				this._items.Filter = x => string.IsNullOrEmpty(this.ItemsFilter) ? true : ((Ville)x).ToString().ToUpper().Contains(this.ItemsFilter.ToUpper());

				this.OnPropertyChanged(""); // raccourci permettant de notifier toutes les propriétés
			}
			catch (Exception ex) {
				NotificationHelper.ShowError(ex);
			}
		}
	}
}
