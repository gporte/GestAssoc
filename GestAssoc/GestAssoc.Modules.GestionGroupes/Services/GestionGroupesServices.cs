using GestAssoc.Model.Libelles;
using GestAssoc.Model.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GestAssoc.Modules.GestionGroupes.Services
{
	public class GestionGroupesServices : IGestionGroupesServices
	{
		private GestAssocContext _context;

		/// <summary>
		/// Constructeur.
		/// </summary>
		public GestionGroupesServices() {
			this._context = new GestAssocContext();
		}
		
		public ObservableCollection<Groupe> GetAllGroupes() {
			var groupes = this._context.Groupes
				.Where(x => x.Saison.EstSaisonCourante)
				.OrderBy(x => x.JourSemaine)
				.ThenBy(x => x.HeureDebut);
			return new ObservableCollection<Groupe>(groupes);
		}

		public Groupe GetGroupe(Guid idGroupe) {
			return this._context.Groupes.Find(idGroupe);
		}

		public void SaveGroupe(Groupe itemToSave) {
			Groupe originalItem = null;

			if (itemToSave.ID != Guid.Empty) {
				originalItem = this._context.Groupes.Find(itemToSave.ID);
			}

			if (originalItem != null) { // item trouvé => update
				this._context.Entry<Groupe>(originalItem).CurrentValues.SetValues(itemToSave);
			}
			else { // item non trouvé => insert
				itemToSave.ID = Guid.NewGuid();
				itemToSave.Saison_ID = itemToSave.Saison.ID;
				itemToSave.Saison = this._context.Saisons.Find(itemToSave.Saison_ID);

				this._context.Groupes.Add(itemToSave);
			}

			this._context.SaveChanges();
		}

		public void DeleteGroupe(Groupe itemToDelete) {
			Groupe originalItem = null;

			if (itemToDelete.ID != Guid.Empty) {
				originalItem = this._context.Groupes.Find(itemToDelete.ID);
			}

			if (originalItem != null) { // item trouvé => delete
				this._context.Groupes.Remove(originalItem);
			}

			this._context.SaveChanges();
		}

		public Saison GetSaisonCourante() {
			return this._context.Saisons.FirstOrDefault(x => x.EstSaisonCourante);
		}

		public IDictionary<int, string> GetJoursSemaine() {
			var joursSemaine = new Dictionary<int, string>();

			joursSemaine.Add(0, LibellesHelper.GetJourSemaineLibelle(0));
			joursSemaine.Add(1, LibellesHelper.GetJourSemaineLibelle(1));
			joursSemaine.Add(2, LibellesHelper.GetJourSemaineLibelle(2));
			joursSemaine.Add(3, LibellesHelper.GetJourSemaineLibelle(3));
			joursSemaine.Add(4, LibellesHelper.GetJourSemaineLibelle(4));
			joursSemaine.Add(5, LibellesHelper.GetJourSemaineLibelle(5));
			joursSemaine.Add(6, LibellesHelper.GetJourSemaineLibelle(6));

			return joursSemaine;
		}
	}
}
