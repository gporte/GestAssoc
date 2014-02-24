﻿using GestAssoc.Common.Constantes;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.GestionSaisons.Services;
using GestAssoc.Modules.GestionSaisons.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace GestAssoc.Modules.GestionSaisons
{
	[Priority(300)]
	public class ModuleGestionSaisons : IModule
	{
		public void Initialize() {
			// trace
			NotificationHelper.WriteNotification("Initialisation du Module GestionSaisons.");

			var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
			var container = ServiceLocator.Current.GetInstance<IUnityContainer>();

			// Enregistrement du RibbonTab
			regionManager.RegisterViewWithRegion(RegionNames.RibbonRegion, typeof(GestionSaisonsRibbonTabView));

			// Enregistrement des vues 
			container.RegisterType<object, ConsultationSaisonsView>(
				ViewNames.ConsultationSaisons
			);
			container.RegisterType<object, FormulaireSaisonView>(
				ViewNames.FormulaireSaison
			);

			// enregistrement des services
			container.RegisterType<IGestionSaisonsServices, GestionSaisonsServices>();

		}
	}
}