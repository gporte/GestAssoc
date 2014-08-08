using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Commands;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.GestionAdhesions.Constantes;
using GestAssoc.Modules.GestionAdhesions.Properties;
using System.Windows.Input;

namespace GestAssoc.Modules.GestionAdhesions.ViewModels
{
	public class GestionAdhesionMenuViewModel : ViewModelBase
	{
		#region Commands
		public ICommand ShowConsultationAdherentsCmd { get; set; }
		public ICommand ShowFormulaireCreationAdherentCmd { get; set; }
		public ICommand ShowConsultationGroupesCmd { get; set; }
		public ICommand ShowFormulaireCreationGroupeCmd { get; set; }
		public ICommand ShowConsultationInscriptionsCmd { get; set; }
		public ICommand ShowFormulaireCreationInscriptionCmd { get; set; }
		public ICommand ShowConsultationSaisonsCmd { get; set; }
		public ICommand ShowFormulaireCreationSaisonCmd { get; set; }
		public ICommand ShowConsultationVillesCmd { get; set; }
		public ICommand ShowFormulaireCreationVilleCmd { get; set; }
		#endregion

		public GestionAdhesionMenuViewModel() {
			this.ShowConsultationAdherentsCmd = new ShowViewCommand(ViewNames.ConsultationAdherents.ToString());
			this.ShowFormulaireCreationAdherentCmd = new ShowViewCommand(ViewNames.FormulaireAdherent.ToString());
			this.ShowConsultationGroupesCmd = new ShowViewCommand(ViewNames.ConsultationGroupes.ToString());
			this.ShowFormulaireCreationGroupeCmd = new ShowViewCommand(ViewNames.FormulaireGroupe.ToString());
			this.ShowConsultationInscriptionsCmd = new ShowViewCommand(ViewNames.ConsultationInscriptions.ToString());
			this.ShowFormulaireCreationInscriptionCmd = new ShowViewCommand(ViewNames.FormulaireInscription.ToString());
			this.ShowConsultationSaisonsCmd = new ShowViewCommand(ViewNames.ConsultationSaisons.ToString());
			this.ShowFormulaireCreationSaisonCmd = new ShowViewCommand(ViewNames.FormulaireSaison.ToString());
			this.ShowConsultationVillesCmd = new ShowViewCommand(ViewNames.ConsultationVilles.ToString());
			this.ShowFormulaireCreationVilleCmd = new ShowViewCommand(ViewNames.FormulaireVille.ToString());

			// trace
			NotificationHelper.WriteLog(Resources.Log_AffichageMenu);
		}
	}
}
