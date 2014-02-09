
namespace GestAssoc.Repository.Model
{
	public partial class Ville
	{
		public override string ToString() {
			return string.Format("{0} - {1}", this.CodePostal.PadLeft(5, ' '), this.Libelle);
		}
	}
}
