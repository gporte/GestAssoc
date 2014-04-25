using GestAssoc.Model.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GestAssoc.Modules.GestionInscriptions.Services
{
	public interface IGestionInscriptionsServices
	{
		/// <summary>
		/// Obtient toutes les inscriptions de la saison courante.
		/// </summary>
		/// <returns>Incriptions pour la saison courante.</returns>
		ObservableCollection<Inscription> GetAllInscriptions();

		/// <summary>
		/// Gets the inscription.
		/// </summary>
		/// <param name="idInscription">The identifier inscription.</param>
		/// <returns></returns>
		Inscription GetInscription(Guid idInscription);

		/// <summary>
		/// Saves the inscription.
		/// </summary>
		/// <param name="itemToSave">The inscription.</param>
		void SaveInscription(Inscription itemToSave);

		/// <summary>
		/// Deletes the inscription.
		/// </summary>
		/// <param name="itemToDelete">The inscription.</param>
		void DeleteInscription(Inscription itemToDelete);

		/// <summary>
		/// Gets all adherents.
		/// </summary>
		/// <returns></returns>
		ObservableCollection<Adherent> GetAllAdherents();

		/// <summary>
		/// Gets all groupes.
		/// </summary>
		/// <returns></returns>
		ObservableCollection<Groupe> GetAllGroupes();

		/// <summary>
		/// Obtient un dictionnaire contenant la liste des statuts ainsi que leur numéro.
		/// </summary>
		/// <returns>Dictionnaire des statuts.</returns>
		IDictionary<int, string> GetStatuts();
	}
}
