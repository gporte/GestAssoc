using GestAssoc.Model.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GestAssoc.Modules.GestionAdhesions.Services
{
	public interface IGestionAdherentsServices
	{
		/// <summary>
		/// Obtient la liste des adhérents.
		/// </summary>
		/// <returns>La liste des adhérents.</returns>
		ObservableCollection<Adherent> GetAllAdherents();

		/// <summary>
		/// Obtient un adhérent identifié par son ID.
		/// </summary>
		/// <param name="idAdherent">ID de l'adhérent.</param>
		/// <returns>Adhérent correspondant à l'ID fourni.</returns>
		Adherent GetAdherent(Guid idAdherent);

		/// <summary>
		/// Enregistre un adhérent (sera créé si n'existe pas en base).
		/// </summary>
		/// <param name="itemToSave">Adhérent à sauver.</param>
		void SaveAdherent(Adherent itemToSave);

		/// <summary>
		/// Supprime un adhérent.
		/// </summary>
		/// <param name="itemToDelete">Adhérent à supprimer.</param>
		void DeleteAdherent(Adherent itemToDelete);

		/// <summary>
		/// Obtient un dictionnaire contenant la liste des sexes ainsi que leur numéro.
		/// </summary>
		/// <returns>Dictionnaire des sexes.</returns>
		IDictionary<int, string> GetSexes();

		/// <summary>
		/// Obtient la liste des villes.
		/// </summary>
		/// <returns>Villes</returns>
		ObservableCollection<Ville> GetAllVilles();
	}
}
