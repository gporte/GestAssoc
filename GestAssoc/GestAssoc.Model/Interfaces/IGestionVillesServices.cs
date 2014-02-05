using GestAssoc.Model.Models;
using System;
using System.Collections.ObjectModel;

namespace GestAssoc.Model.Interfaces
{
	public interface IGestionVillesServices
	{
		ObservableCollection<Ville> GetAllVilles();
		Ville GetVille(Guid idVille);
	}
}
