using GestAssoc.Model.Models;
using System;
using System.Collections.ObjectModel;

namespace GestAssoc.Modules.GestionSaisons.Services
{
	public interface IGestionSaisonsServices
	{
		/// <summary>
		/// Obtient la liste des saisons.
		/// </summary>
		/// <returns>Liste des saisons.</returns>
		ObservableCollection<Saison> GetAllSaisons();

		/// <summary>
		/// Obtient une saison identifiée par son ID
		/// </summary>
		/// <param name="idSaison">ID de la saison</param>
		/// <returns>Saison correspondant à l'ID fourni.</returns>
		Saison GetSaison(Guid idSaison);

		/// <summary>
		/// Obtient la saison courante.
		/// </summary>
		/// <returns>Saison courante.</returns>
		Saison GetSaisonCourante();

		/// <summary>
		/// Enregistre une saison (sera créée si n'existe pas en base).
		/// </summary>
		/// <param name="itemToSave">Saison à enregistrer.</param>
		void SaveSaison(Saison itemToSave);

		/// <summary>
		/// Supprime une saison.
		/// </summary>
		/// <param name="itemToDelete">Saison à supprimer.</param>
		void DeleteSaison(Saison itemToDelete);

		/// <summary>
		/// Définit la saison courante.
		/// </summary>
		/// <param name="newSaisonCourante">Nouvelle saison courante.</param>
		void SetSaisonCourante(Saison newSaisonCourante);
	}
}
