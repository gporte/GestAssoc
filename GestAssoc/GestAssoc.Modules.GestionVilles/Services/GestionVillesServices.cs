using GestAssoc.Model.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace GestAssoc.Modules.GestionVilles.Services
{
	public class GestionVillesServices : IGestionVillesServices
	{
		private GestAssocContext _context;

		public GestionVillesServices() {
			this._context = new GestAssocContext();
		}
		
		public ObservableCollection<Model.Models.Ville> GetAllVilles() {
			var villes = this._context.Villes.OrderBy(x => x.CodePostal).ThenBy(x => x.Libelle);
			return new ObservableCollection<Ville>(villes);
		}

		public Ville GetVille(System.Guid idVille) {
			return this._context.Villes.Find(idVille);
		}

		public void SaveVille(Ville itemToSave) {
			Ville originalItem = null;

			if (itemToSave.ID != Guid.Empty) {
				originalItem = this._context.Villes.Find(itemToSave.ID);
			}

			if (originalItem != null) { // item trouvé => update
				this._context.Entry<Ville>(originalItem).CurrentValues.SetValues(itemToSave);				
			}
			else { // item non trouvé => insert
				itemToSave.ID = Guid.NewGuid();
				this._context.Villes.Add(itemToSave);
			}
			
			this._context.SaveChanges();
		}

		public void DeleteVille(Ville itemToDelete) {
			Ville originalItem = null;

			if (itemToDelete.ID != Guid.Empty) {
				originalItem = this._context.Villes.Find(itemToDelete.ID);
			}

			if (originalItem != null) { // item trouvé => delete
				this._context.Villes.Remove(originalItem);
			}

			this._context.SaveChanges();
		}
	}
}
