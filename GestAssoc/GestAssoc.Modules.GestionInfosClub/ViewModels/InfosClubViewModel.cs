﻿using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Constantes;
using GestAssoc.Model.Models;
using GestAssoc.Modules.GestionInfosClub.Services;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace GestAssoc.Modules.GestionInfosClub.ViewModels
{
	public class InfosClubViewModel : ViewModelBase
	{
		private IGestionInfosClubServices _services;

		public ShowViewCommandWithParameter ShowEditViewCmd { get; set; }

		#region Item property
		private InfosClub _item;
		public InfosClub Item {
			get { return this._item; }
			set {
				if (this._item != value) {
					this._item = value;
					this.RaisePropertyChangedEvent("Item");
				}
			}
		}
		#endregion

		public InfosClubViewModel() {
			this._services = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IGestionInfosClubServices>();

			this.ShowEditViewCmd = new ShowViewCommandWithParameter(ViewNames.FormulaireInfosClub);

			this.Item = this._services.GetInfosClub();
		}
	}
}
