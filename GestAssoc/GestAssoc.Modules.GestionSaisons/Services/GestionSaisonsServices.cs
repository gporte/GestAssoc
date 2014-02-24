using GestAssoc.Model.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace GestAssoc.Modules.GestionSaisons.Services
{
	public class GestionSaisonsServices : IGestionSaisonsServices
	{
		private GestAssocContext _context;

		/// <summary>
		/// Constructeur.
		/// </summary>
		public GestionSaisonsServices() {
			this._context = new GestAssocContext();
		}
		
		public ObservableCollection<Saison> GetAllSaisons() {
			var saisons = this._context.Saisons.OrderBy(x => x.AnneeDebut);
			return new ObservableCollection<Saison>(saisons);
		}

		public Model.Models.Saison GetSaison(Guid idSaison) {
			return this._context.Saisons.Find(idSaison);
		}

		public Model.Models.Saison GetSaisonCourante() {
			return this._context.Saisons.FirstOrDefault(x => x.EstSaisonCourante);
		}

		public void SaveSaison(Saison itemToSave) {
			Saison originalItem = null;

			if (itemToSave.ID != Guid.Empty) {
				originalItem = this._context.Saisons.Find(itemToSave.ID);
			}

			if (originalItem != null) { // item trouvé => update
				this._context.Entry<Saison>(originalItem).CurrentValues.SetValues(itemToSave);
			}
			else { // item non trouvé => insert
				itemToSave.ID = Guid.NewGuid();
				this._context.Saisons.Add(itemToSave);
			}

			this._context.SaveChanges();
		}

		public void DeleteSaison(Saison itemToDelete) {
			Saison originalItem = null;

			if (itemToDelete.ID != Guid.Empty) {
				originalItem = this._context.Saisons.Find(itemToDelete.ID);
			}

			if (originalItem != null) { // item trouvé => delete
				this._context.Saisons.Remove(originalItem);
			}

			this._context.SaveChanges();
		}

		public void SetSaisonCourante(Saison newSaisonCourante) {
			var oldSaisonCourante = this.GetSaisonCourante();

			if (oldSaisonCourante != null) { // ancienne saison courante trouvée => modification
				oldSaisonCourante.EstSaisonCourante = false;
				this._context.Entry<Saison>(oldSaisonCourante).CurrentValues.SetValues(oldSaisonCourante);
			}

			var originalNewSaisonCourante = this._context.Saisons.Find(newSaisonCourante.ID);
			newSaisonCourante.EstSaisonCourante = true;
			this._context.Entry<Saison>(originalNewSaisonCourante).CurrentValues.SetValues(newSaisonCourante);

			this._context.SaveChanges();
		}
	}
}
