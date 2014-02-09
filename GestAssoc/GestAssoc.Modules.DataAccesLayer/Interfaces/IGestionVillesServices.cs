using GestAssoc.Model.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GestAssoc.Modules.DataAccesLayer.Interfaces
{
	public interface IGestionVillesServices
	{
		ObservableCollection<Ville> GetAllVilles();
	}
}
