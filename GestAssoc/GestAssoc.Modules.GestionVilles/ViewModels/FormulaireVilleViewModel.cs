using GestAssoc.Common.BaseClasses;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionVilles.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;

namespace GestAssoc.Modules.GestionVilles.ViewModels
{
	public class FormulaireVilleViewModel : ViewModelBase
	{
		private bool _isCreation = false;
		private IGestionVillesServices _services;

		#region Item property
		private Ville _item;
		public Ville Item {
			get { return this._item; }
			set {
				if (this._item != value) {
					this._item = value;
					this.RaisePropertyChangedEvent("Item");
				}
			}
		}
		#endregion

		#region Constructors
		public FormulaireVilleViewModel(Guid itemId) {
			this._services = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionVillesServices>();

			if (itemId == Guid.Empty) {
				this._isCreation = true;
				this.Item = new Ville();
			}
			else {
				this._isCreation = false;
				this.Item = this._services.GetVille(itemId);
			}
		}
		#endregion
	}
}
