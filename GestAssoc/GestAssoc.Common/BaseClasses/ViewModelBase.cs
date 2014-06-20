using GestAssoc.Common.Utility;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Prism.Mvvm;

namespace GestAssoc.Common.BaseClasses
{
	/// <summary>
	/// ViewModel de base pour toute l'application.
	/// Servira à implémenter les fonctionnalitées communes à tous les écrans.
	/// </summary>
	public abstract class ViewModelBase : BindableBase
	{
		protected ViewModelBase() {
		}
	}
}
