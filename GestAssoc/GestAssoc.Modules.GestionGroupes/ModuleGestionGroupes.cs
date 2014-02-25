﻿using GestAssoc.Common.Constantes;
using GestAssoc.Common.Utility;
using GestAssoc.Modules.GestionGroupes.Services;
using GestAssoc.Modules.GestionGroupes.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace GestAssoc.Modules.GestionGroupes
{
	[Priority(400)]
	public class ModuleGestionGroupes : IModule
	{
		public void Initialize() {
			// trace
			NotificationHelper.WriteNotification("Initialisation du Module GestionGroupes.");

			var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
			var container = ServiceLocator.Current.GetInstance<IUnityContainer>();

			// Enregistrement du RibbonTab
			regionManager.RegisterViewWithRegion(RegionNames.RibbonRegion, typeof(GestionGroupesRibbonTabView));

			// Enregistrement des vues 
			container.RegisterType<object, ConsultationGroupesView>(
				ViewNames.ConsultationGroupes
			);
			container.RegisterType<object, FormulaireGroupeView>(
				ViewNames.FormulaireGroupe
			);

			// enregistrement des services
			container.RegisterType<IGestionGroupesServices, GestionGroupesServices>();
		}
	}
}
