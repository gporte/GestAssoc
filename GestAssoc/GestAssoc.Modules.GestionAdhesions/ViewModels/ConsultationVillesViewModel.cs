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
	public class ConsultationVillesViewModel : ViewModelBase
	{
		private IGestionVillesServices _services;
		
		#region Items property
		private ICollectionView _items;
		public ObservableCollection<Ville> Items { get; private set; }
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

		public ICommand EditVilleCmd { get; set; }		
		public ICommand AddVilleCmd { get; set; }
		public ICommand DeleteVilleCmd { get; set; }

		public ConsultationVillesViewModel() {
			// enregistrement et initialisation des services
			ServiceLocator.Current.GetInstance<IUnityContainer>().RegisterType<IGestionVillesServices, GestionVillesServices>();
			
			this._services = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionVillesServices>();

			this.LoadItems();

			this.EditVilleCmd = new ShowViewCommandWithParameter(ViewNames.FormulaireVille.ToString());
			this.AddVilleCmd = new ShowViewCommand(ViewNames.FormulaireVille.ToString());
			this.DeleteVilleCmd = new DeleteVilleCommand(this.LoadItems);

			// trace
			NotificationHelper.WriteLog(GlblRes.Log_AffichageVue + ViewNames.ConsultationVilles.ToString());
		}

		private void LoadItems() {
			try {
				UIServices.SetBusyState();
				this.Items = new ObservableCollection<Ville>(this._services.GetAllVilles());
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
