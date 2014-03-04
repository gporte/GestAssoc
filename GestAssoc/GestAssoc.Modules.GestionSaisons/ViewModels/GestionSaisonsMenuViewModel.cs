using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Constantes;
using GestAssoc.Common.Utility;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionSaisons.ViewModels
{
	public class GestionSaisonsMenuViewModel : ViewModelBase
	{
		public ICommand ShowConsultationSaisonsCmd { get; set; }
		public ICommand ShowFormulaireCreationSaisonCmd { get; set; }

		public GestionSaisonsMenuViewModel() {
			this.ShowConsultationSaisonsCmd = new ShowViewCommand(ViewNames.ConsultationSaisons);
			this.ShowFormulaireCreationSaisonCmd = new ShowViewCommand(ViewNames.FormulaireSaison);

			// trace
			NotificationHelper.WriteNotification("Affichage du RibbonTab GestionSaisons");
		}
	}
}
