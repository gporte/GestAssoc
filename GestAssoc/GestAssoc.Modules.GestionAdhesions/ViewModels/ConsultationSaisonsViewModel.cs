using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionAdhesions.Commands;
using GestAssoc.Modules.GestionAdhesions.Constantes;
using GestAssoc.Modules.GestionAdhesions.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using GlblRes = global::GestAssoc.Modules.GestionAdhesions.Properties.Resources;

namespace GestAssoc.Modules.GestionAdhesions.ViewModels
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
				this._items.Refresh();
				this.SetProperty(ref this._itemsFilter, value);
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
			// enregistrement et initialisation des services
			ServiceLocator.Current.GetInstance<IUnityContainer>().RegisterType<IGestionSaisonsServices, GestionSaisonsServices>();
			
			this._services = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionSaisonsServices>();

			this.LoadItems();

			this.EditSaisonCmd = new ShowViewCommandWithParameter(ViewNames.FormulaireSaison.ToString());
			this.DeleteSaisonCmd = new DeleteSaisonCommand(this.LoadItems);
			this.AddSaisonCmd = new ShowViewCommand(ViewNames.FormulaireSaison.ToString());
			this.ChangeSaisonCouranteCmd = new ChangeSaisonCouranteCommand();

			// trace
			NotificationHelper.WriteLog(GlblRes.Log_AffichageVue + ViewNames.ConsultationSaisons.ToString());
		}

		private void LoadItems() {
			try {
				UIServices.SetBusyState();
				this.Items = new ObservableCollection<Saison>(this._services.GetAllSaisons());
				this._items = CollectionViewSource.GetDefaultView(this.Items);
				this._items.Filter = x => string.IsNullOrEmpty(this.ItemsFilter) ? true : ((Saison)x).ToString().ToUpper().Contains(this.ItemsFilter.ToUpper());

				this.OnPropertyChanged(""); // raccourci permettant de notifier toutes les propriétés
			}
			catch (Exception ex) {
				NotificationHelper.ShowError(ex);
			}
		}
	}
}
