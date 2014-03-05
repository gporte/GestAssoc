using GestAssoc.Model.Libelles;
using GestAssoc.Model.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GestAssoc.Modules.GestionAdherents.Services
{
	public class GestionAdherentsServices : IGestionAdherentsServices
	{
		private GestAssocContext _context;

		/// <summary>
		/// Constructeur.
		/// </summary>
		public GestionAdherentsServices() {
			this._context = new GestAssocContext();
		}
		
		public ObservableCollection<Adherent> GetAllAdherents() {
			var adherents = this._context.Adherents.OrderBy(x => x.Nom).ThenBy(x => x.Prenom);
			return new ObservableCollection<Adherent>(adherents);
		}

		public Adherent GetAdherent(Guid idAdherent) {
			return this._context.Adherents.Find(idAdherent);
		}

		public void SaveAdherent(Adherent itemToSave) {
			Adherent originalItem = null;

			if (itemToSave.ID != Guid.Empty) {
				originalItem = this._context.Adherents.Find(itemToSave.ID);
			}

			if (originalItem != null) { // item trouvé => update
				originalItem.DateModification = DateTime.Now;
				this._context.Entry<Adherent>(originalItem).CurrentValues.SetValues(itemToSave);
			}
			else { // item non trouvé => insert
				itemToSave.ID = Guid.NewGuid();
				itemToSave.Ville_ID = itemToSave.Ville.ID;
				itemToSave.Ville = this._context.Villes.Find(itemToSave.Ville_ID);
				itemToSave.DateCreation = DateTime.Now;

				this._context.Adherents.Add(itemToSave);
			}

			this._context.SaveChanges();
		}

		public void DeleteAdherent(Adherent itemToDelete) {
			Adherent originalItem = null;

			if (itemToDelete.ID != Guid.Empty) {
				originalItem = this._context.Adherents.Find(itemToDelete.ID);
			}

			if (originalItem != null) { // item trouvé => delete
				this._context.Adherents.Remove(originalItem);
			}

			this._context.SaveChanges();
		}
		
		public IDictionary<int, string> GetSexes() {
			var sexes = new Dictionary<int, string>();

			sexes.Add(0, LibellesHelper.GetSexeLibelle(0));
			sexes.Add(1, LibellesHelper.GetSexeLibelle(1));

			return sexes;
		}

		public ObservableCollection<Ville> GetAllVilles() {
			var villes = this._context.Villes.OrderBy(x => x.CodePostal).ThenBy(x => x.Libelle);
			return new ObservableCollection<Ville>(villes);
		}
	}
}
