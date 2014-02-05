using GestAssoc.Model.Interfaces;
using GestAssoc.Model.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace GestAssoc.Model.Services
{
	public class GestionVillesServices : IGestionVillesServices
	{
		private GestAssocContext _context;

		public GestionVillesServices() {
			this._context = new GestAssocContext();
		}

		public ObservableCollection<Model.Models.Ville> GetAllVilles() {
			var villes = this._context.Villes.OrderBy(x => x.CodePostal).ThenBy(x => x.Libelle);
			return new ObservableCollection<Ville>(villes);
		}
	}
}
