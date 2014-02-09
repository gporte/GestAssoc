using GestAssoc.Model.Models;
using System.Collections.ObjectModel;

namespace GestAssoc.Modules.GestionInfosClub.Services
{
	public interface IGestionInfosClubServices
	{
		InfosClub GetInfosClub();
		ObservableCollection<Ville> GetAllVilles();
		void SaveInfosClub(InfosClub itemToSave);
	}
}
