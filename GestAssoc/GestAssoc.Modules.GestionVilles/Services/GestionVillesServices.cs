﻿using GestAssoc.Model.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace GestAssoc.Modules.GestionVilles.Services
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

		public Ville GetVille(System.Guid idVille) {
			return this._context.Villes.Find(idVille);
		}
	}
}