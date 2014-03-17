using GestAssoc.Model.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestAssoc.Modules.GestionInscriptions.Services
{
	public class GestionInscriptionServices : IGestionInscriptionsServices
	{
		private GestAssocContext _context;

		/// <summary>
		/// Initializes a new instance of the <see cref="GestionInscriptionServices"/> class.
		/// </summary>
		public GestionInscriptionServices() {
			this._context = new GestAssocContext();
		}

		/// <summary>
		/// Obtient toutes les inscriptions de la saison courante.
		/// </summary>
		/// <returns>
		/// Incriptions pour la saison courante.
		/// </returns>
		public ObservableCollection<Inscription> GetAllInscriptions() {
			var inscriptions = this._context.Inscriptions
				.Where(x => x.Groupe.Saison.EstSaisonCourante)
				.OrderBy(x => x.Groupe)
				.ThenBy(x => x.Adherent);

			return new ObservableCollection<Inscription>(inscriptions);
		}

		/// <summary>
		/// Gets the inscription.
		/// </summary>
		/// <param name="idInscription">The identifier inscription.</param>
		/// <returns></returns>
		public Inscription GetInscription(Guid idInscription) {
			return this._context.Inscriptions.Find(idInscription);
		}

		/// <summary>
		/// Saves the inscription.
		/// </summary>
		/// <param name="itemToSave">The inscription.</param>
		public void SaveInscription(Inscription itemToSave) {
			Inscription originalItem = null;

			if (itemToSave.ID != Guid.Empty) {
				originalItem = this._context.Inscriptions.Find(itemToSave.ID);
			}

			if (originalItem != null) { // item trouvé => update
				originalItem.DateModification = DateTime.Now;
				this._context.Entry<Inscription>(originalItem).CurrentValues.SetValues(itemToSave);
			}
			else { // item non trouvé => insert
				itemToSave.ID = Guid.NewGuid();

				itemToSave.Adherent_ID = itemToSave.Adherent.ID;
				itemToSave.Adherent = this._context.Adherents.Find(itemToSave.Adherent_ID);

				itemToSave.Groupe_ID = itemToSave.Groupe.ID;
				itemToSave.Groupe = this._context.Groupes.Find(itemToSave.Groupe_ID);

				itemToSave.Section_ID = itemToSave.Section.ID;
				itemToSave.Section = this._context.Sections.Find(itemToSave.Section_ID);

				itemToSave.DateCreation = DateTime.Now;

				this._context.Inscriptions.Add(itemToSave);
			}

			this._context.SaveChanges();
		}

		/// <summary>
		/// Deletes the inscription.
		/// </summary>
		/// <param name="itemToDelete">The inscription.</param>
		public void DeleteInscription(Inscription itemToDelete) {
			Inscription originalItem = null;

			if (itemToDelete.ID != Guid.Empty) {
				originalItem = this._context.Inscriptions.Find(itemToDelete.ID);
			}

			if (originalItem != null) { // item trouvé => delete
				this._context.Inscriptions.Remove(originalItem);
			}

			this._context.SaveChanges();
		}

		/// <summary>
		/// Gets all adherents.
		/// </summary>
		/// <returns></returns>
		public ObservableCollection<Adherent> GetAllAdherents() {
			var adherents = this._context.Adherents.OrderBy(x => x.Nom).ThenBy(x => x.Prenom);
			return new ObservableCollection<Adherent>(adherents);
		}

		/// <summary>
		/// Gets all groupes.
		/// </summary>
		/// <returns></returns>
		public ObservableCollection<Groupe> GetAllGroupes() {
			var groupes = this._context.Groupes
				.Where(x => x.Saison.EstSaisonCourante)
				.OrderBy(x => x.JourSemaine)
				.ThenBy(x => x.HeureDebut);

			return new ObservableCollection<Groupe>(groupes);
		}
	}
}
