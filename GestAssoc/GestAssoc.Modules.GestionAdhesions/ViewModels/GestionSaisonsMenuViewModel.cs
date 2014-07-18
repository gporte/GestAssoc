using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.GestionAdhesions.Constantes;
using System.Windows.Input;
using GlblRes = global::GestAssoc.Modules.GestionAdhesions.Properties.Resources;

namespace GestAssoc.Modules.GestionAdhesions.ViewModels
{
	public class GestionSaisonsMenuViewModel : ViewModelBase
	{
		public ICommand ShowConsultationSaisonsCmd { get; set; }
		public ICommand ShowFormulaireCreationSaisonCmd { get; set; }

		public GestionSaisonsMenuViewModel() {
			this.ShowConsultationSaisonsCmd = new ShowViewCommand(ViewNames.ConsultationSaisons.ToString());
			this.ShowFormulaireCreationSaisonCmd = new ShowViewCommand(ViewNames.FormulaireSaison.ToString());

			// trace
			NotificationHelper.WriteLog(GlblRes.Log_Sai_AffichageMenu);
		}
	}
}
