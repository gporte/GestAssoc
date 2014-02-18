using GestAssoc.Model.Models;
using System;
using System.Collections.ObjectModel;

namespace GestAssoc.Modules.GestionVilles.Services
{
	public interface IGestionVillesServices
	{
		ObservableCollection<Ville> GetAllVilles();
		Ville GetVille(Guid idVille);
		void SaveVille(Ville itemToSave);
	}
}
