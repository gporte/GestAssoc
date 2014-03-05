using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.GestionSaisons.Constantes;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionSaisons.ViewModels
{
	public class GestionSaisonsMenuViewModel : ViewModelBase
	{
		public ICommand ShowConsultationSaisonsCmd { get; set; }
		public ICommand ShowFormulaireCreationSaisonCmd { get; set; }

		public GestionSaisonsMenuViewModel() {
			this.ShowConsultationSaisonsCmd = new ShowViewCommand(ViewNames.ConsultationSaisons.ToString());
			this.ShowFormulaireCreationSaisonCmd = new ShowViewCommand(ViewNames.FormulaireSaison.ToString());

			// trace
			NotificationHelper.WriteNotification("Affichage du RibbonTab GestionSaisons");
		}
	}
}
