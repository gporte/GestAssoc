using GestAssoc.Model.Models;
using System.Collections.ObjectModel;

namespace GestAssoc.Model.Interfaces
{
	public interface IGestionVillesServices
	{
		ObservableCollection<Ville> GetAllVilles();
	}
}
