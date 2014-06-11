using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionGroupes.Commands;
using GestAssoc.Modules.GestionGroupes.Constantes;
using GestAssoc.Modules.GestionGroupes.Properties;
using GestAssoc.Modules.GestionGroupes.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionGroupes.ViewModels
{
	public class ConsultationGroupesViewModel : ViewModelBase
	{
		private IGestionGroupesServices _services;

		#region Items property
		private ICollectionView _items;
		public ObservableCollection<Groupe> Items { get; private set; }
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

		public ICommand EditGroupeCmd { get; set; }
		public ICommand DeleteGroupeCmd { get; set; }
		public ICommand AddGroupeCmd { get; set; }

		public ConsultationGroupesViewModel() {
			// enregistrement et initialisation des services
			ServiceLocator.Current.GetInstance<IUnityContainer>()
				.RegisterType<IGestionGroupesServices, GestionGroupesServices>();

			this._services = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionGroupesServices>();

			try {
				UIServices.SetBusyState();
				this.Items = new ObservableCollection<Groupe>(this._services.GetAllGroupes());
				this._items = CollectionViewSource.GetDefaultView(this.Items);
				this._items.Filter = x => string.IsNullOrEmpty(this.ItemsFilter) ? true : ((Groupe)x).ToString().ToUpper().Contains(this.ItemsFilter.ToUpper());
			}
			catch (Exception ex) {
				NotificationHelper.ShowError(ex);
			}

			this.EditGroupeCmd = new ShowViewCommandWithParameter(ViewNames.FormulaireGroupe.ToString());
			this.DeleteGroupeCmd = new DeleteGroupeCommand();
			this.AddGroupeCmd = new ShowViewCommand(ViewNames.FormulaireGroupe.ToString());

			// trace
			NotificationHelper.WriteNotification(Resources.Log_AffichageVue + ViewNames.ConsultationGroupes.ToString());
		}
	}
}
