using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionVilles.Commands;
using GestAssoc.Modules.GestionVilles.Constantes;
using GestAssoc.Modules.GestionVilles.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionVilles.ViewModels
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
				if (this._itemsFilter != value) {
					this._itemsFilter = value;
					this._items.Refresh();
					this.RaisePropertyChangedEvent("ItemsFilter");
				}
			}
		}
		#endregion

		public ICommand EditVilleCmd { get; set; }
		public ICommand DeleteVilleCmd { get; set; }
		public ICommand AddVilleCmd { get; set; }

		public ConsultationVillesViewModel() {
			this._services = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionVillesServices>();

			try {
				UIServices.SetBusyState();
				this.Items = new ObservableCollection<Ville>(this._services.GetAllVilles());
				this._items = CollectionViewSource.GetDefaultView(this.Items);
				this._items.Filter = x => string.IsNullOrEmpty(this.ItemsFilter) ? true : ((Ville)x).ToString().ToUpper().Contains(this.ItemsFilter.ToUpper());
			}
			catch (Exception ex) {
				NotificationHelper.ShowError(ex);
			}

			this.EditVilleCmd = new ShowViewCommandWithParameter(ViewNames.FormulaireVille.ToString());
			this.DeleteVilleCmd = new DeleteVilleCommand();
			this.AddVilleCmd = new ShowViewCommand(ViewNames.FormulaireVille.ToString());

			// trace
			NotificationHelper.WriteNotification("Affichage de la vue " + ViewNames.ConsultationVilles.ToString());
		}
	}
}
