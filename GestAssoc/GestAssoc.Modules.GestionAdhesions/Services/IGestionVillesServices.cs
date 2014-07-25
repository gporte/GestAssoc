using GestAssoc.Model.Models;
using System;
using System.Collections.ObjectModel;

namespace GestAssoc.Modules.GestionAdhesions.Services
{
	public interface IGestionVillesServices
	{
		ObservableCollection<Ville> GetAllVilles();
		Ville GetVille(Guid idVille);
		bool SaveVille(Ville itemToSave);
		void DeleteVille(Ville itemToDelete);
	}
}
