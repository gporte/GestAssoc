using GestAssoc.Model.Interfaces;
using GestAssoc.Model.Models;
using System.Linq;

namespace GestAssoc.Model.Services
{
	public class GestionInfosClubServices : BaseServices, IGestionInfosClubServices
	{
		public InfosClub GetInfosClub() {
			return this._context.InfosClubs.First();
		}
	}
}
