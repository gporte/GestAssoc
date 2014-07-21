﻿using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.GestionAdhesions.Constantes;
using GestAssoc.Modules.GestionAdhesions.Properties;
using GestAssoc.Modules.GestionAdhesions.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace GestAssoc.Modules.GestionAdhesions
{
	[Priority(200)]
	public class ModuleGestionAdhesions : ModuleBase, IModule
	{
		public void Initialize() {
			// trace
			NotificationHelper.WriteLog(Resources.Log_InitialisationModule);

			var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
			var container = ServiceLocator.Current.GetInstance<IUnityContainer>();

			// Enregistrement du RibbonTab
			regionManager.RegisterViewWithRegion(this.GetRegionName(RibbonTabRegion.Inscriptions), typeof(GestionGroupesMenuView));
			regionManager.RegisterViewWithRegion(this.GetRegionName(RibbonTabRegion.Inscriptions), typeof(GestionAdherentsMenuView));			
			regionManager.RegisterViewWithRegion(this.GetRegionName(RibbonTabRegion.Inscriptions), typeof(GestionInscriptionsMenuView));

			regionManager.RegisterViewWithRegion(this.GetRegionName(RibbonTabRegion.Referentiel), typeof(GestionSaisonsMenuView));
			regionManager.RegisterViewWithRegion(this.GetRegionName(RibbonTabRegion.Referentiel), typeof(GestionVillesMenuView));

			// Enregistrement des vues 
			container.RegisterType<object, ConsultationAdherentsView>(
				ViewNames.ConsultationAdherents.ToString()
			);
			container.RegisterType<object, FormulaireAdherentView>(
				ViewNames.FormulaireAdherent.ToString()
			);

			container.RegisterType<object, ConsultationGroupesView>(
				ViewNames.ConsultationAdherents.ToString()
			);
			container.RegisterType<object, FormulaireGroupeView>(
				ViewNames.FormulaireAdherent.ToString()
			);

			container.RegisterType<object, ConsultationSaisonsView>(
				ViewNames.ConsultationSaisons.ToString()
			);
			container.RegisterType<object, FormulaireSaisonView>(
				ViewNames.FormulaireSaison.ToString()
			);

			container.RegisterType<object, ConsultationInscriptionsView>(
				ViewNames.ConsultationInscriptions.ToString()
			);
			container.RegisterType<object, FormulaireInscriptionView>(
				ViewNames.FormulaireInscription.ToString()
			);

			container.RegisterType<object, ConsultationVillesView>(
				ViewNames.ConsultationVilles.ToString()
			);
			container.RegisterType<object, FormulaireVilleView>(
				ViewNames.FormulaireVille.ToString()
			);
		}
	}
}
