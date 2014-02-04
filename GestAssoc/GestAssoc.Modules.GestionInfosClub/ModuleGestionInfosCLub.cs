using GestAssoc.Modules.GestionInfosClub.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace GestAssoc.Modules.GestionInfosClub
{
	public class ModuleGestionInfosCLub : IModule
	{
		public void Initialize() {
			var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
			container.RegisterType<object, InfosClubView>(typeof(InfosClubView).Name);
		}
	}
}
