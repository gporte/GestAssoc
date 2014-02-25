﻿using GestAssoc.Model.Models;
using System;
using System.Collections.ObjectModel;

namespace GestAssoc.Modules.GestionGroupes.Services
{
	public interface IGestionGroupesServices
	{
		/// <summary>
		/// Obtient la liste des groupes (pour la saison courante).
		/// </summary>
		/// <returns>La liste des groupes.</returns>
		ObservableCollection<Groupe> GetAllGroupes();

		/// <summary>
		/// Obtient un groupe identifié par son ID.
		/// </summary>
		/// <param name="idGroupe">ID du groupe.</param>
		/// <returns>Groupe correspondant à l'ID fourni.</returns>
		Groupe GetGroupe(Guid idGroupe);

		/// <summary>
		/// Enregistre un groupe(sera créé si n'existe pas en base).
		/// </summary>
		/// <param name="itemToSave">Groupe à sauver.</param>
		void SaveGroupe(Groupe itemToSave);

		/// <summary>
		/// Supprime un groupe.
		/// </summary>
		/// <param name="itemToDelete">Groupe à supprimer.</param>
		void DeleteGroupe(Groupe itemToDelete);
	}
}
