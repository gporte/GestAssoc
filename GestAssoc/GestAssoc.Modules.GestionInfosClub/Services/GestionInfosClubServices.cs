﻿using GestAssoc.Model.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace GestAssoc.Modules.GestionInfosClub.Services
{
	public class GestionInfosClubServices : IGestionInfosClubServices, IDisposable
	{
		private GestAssocContext _context;

		public GestionInfosClubServices() {
			this._context = new GestAssocContext();
		}

		public Model.Models.InfosClub GetInfosClub() {
			return this._context.InfosClubs.First();
		}

		public System.Collections.ObjectModel.ObservableCollection<Model.Models.Ville> GetAllVilles() {
			var villes = this._context.Villes.OrderBy(x => x.CodePostal).ThenBy(x => x.Libelle);
			return new ObservableCollection<Ville>(villes);
		}

		public void SaveInfosClub(Model.Models.InfosClub itemToSave) {
			var originalItem = this._context.InfosClubs.Find(itemToSave.ID);

			if (originalItem != null) {
				this._context.Entry<InfosClub>(originalItem).CurrentValues.SetValues(itemToSave);
				this._context.SaveChanges();
			}
		}

		public void Dispose() {
			this.Dispose(true);
		}

		protected virtual void Dispose(bool disposing) {
			if (disposing) {
				if (this._context != null) {
					this._context.Dispose();
					this._context = null;
				}
			}
		}
	}
}
