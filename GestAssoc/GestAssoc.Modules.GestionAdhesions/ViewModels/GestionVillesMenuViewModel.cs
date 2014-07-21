using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.GestionAdhesions.Constantes;
using System.Windows.Input;
using GlblRes = global::GestAssoc.Modules.GestionAdhesions.Properties.Resources;

namespace GestAssoc.Modules.GestionAdhesions.ViewModels
{
	public class GestionVillesMenuViewModel : ViewModelBase

	{
		public ICommand ShowConsultationVillesCmd { get; set; }
		public ICommand ShowFormulaireCreationVilleCmd { get; set; }

		public GestionVillesMenuViewModel() {
			this.ShowConsultationVillesCmd = new ShowViewCommand(ViewNames.ConsultationVilles.ToString());
			this.ShowFormulaireCreationVilleCmd = new ShowViewCommand(ViewNames.FormulaireVille.ToString());

			// trace
			NotificationHelper.WriteLog(GlblRes.Log_Vil_AffichageMenu);
		}
	}
}
