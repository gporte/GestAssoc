using GestAssoc.Common.Utility;
using GestAssoc.Model.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GlblRes = global::GestAssoc.Modules.GestionAdhesions.Properties.Resources;

namespace GestAssoc.Modules.GestionAdhesions.Services
{
	public class GestionVillesServices : IGestionVillesServices, IDisposable
	{
		private GestAssocContext _context;

		/// <summary>
		/// Constructeur.
		/// </summary>
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

		public bool SaveVille(Ville itemToSave) {
			try {
				UIServices.SetBusyState();
				List<string> errorsList;
				bool isValid = this.IsValidForSaving(itemToSave, out errorsList);

				if (!isValid) {
					NotificationHelper.ShowUserNotification(string.Join(Environment.NewLine, errorsList.ToArray()));
					errorsList.Insert(0, GlblRes.Log_Vil_EnregistrementAnnule);
					NotificationHelper.WriteLogs(errorsList);
				}
				else {
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
					NotificationHelper.WriteLog(GlblRes.Log_Vil_EnregistrementEffectue + itemToSave.ToString());
				}

				return isValid;
			}
			catch (Exception ex) {
				NotificationHelper.ShowError(ex);
				return false;
			}
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

		private bool IsValidForSaving(Ville itemToSave, out List<string> errorsList) {
			errorsList = new List<string>();

			if (string.IsNullOrWhiteSpace(itemToSave.Libelle)) {
				errorsList.Add(GlblRes.Err_Vil_LibelleObligatoire);
			}

			if (string.IsNullOrWhiteSpace(itemToSave.CodePostal)) {
				errorsList.Add(GlblRes.Err_Vil_CodePostalObligatoire);
			}

			// on vérifie qu'il n'y a pas déjà un item différent (ID différent) mais avec le même couple code postal+libellé
			var itemExists = this.GetAllVilles().Count(x => x.ToString() == itemToSave.ToString() && x.ID != itemToSave.ID) > 0;

			if (itemExists) {
				errorsList.Add(GlblRes.Err_Vil_Existe);
			}

			return errorsList.Count == 0;
		}
	}
}
