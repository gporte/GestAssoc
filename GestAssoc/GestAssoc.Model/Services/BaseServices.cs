using GestAssoc.Model.Models;

namespace GestAssoc.Model.Services
{
	public abstract class BaseServices
	{
		protected GestAssocContext _context;

		protected BaseServices() {
			this._context = new GestAssocContext();
		}
	}
}
