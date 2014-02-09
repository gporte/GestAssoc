using GestAssoc.Common.BaseClasses;
using GestAssoc.Common.Event;
using GestAssoc.Common.Utility;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;

namespace GestAssoc.ViewModels
{
	public class ShellWindowViewModel : ViewModelBase
	{
		#region NotificationsProperty
		private string _notifications;
		public string Notifications {
			get { return this._notifications; }
			set {
				if (this._notifications != value) {
					this._notifications = value;
					this.RaisePropertyChangedEvent("Notifications");
				}
			}
		}
		#endregion

		private IEventAggregator _aggregator;

		public ShellWindowViewModel() {
			this._aggregator = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IEventAggregator>();

			this._aggregator.GetEvent<NotificationEvent>().Subscribe(this.WriteNotification);
		}

		private void WriteNotification(UserNotification notification) {
			if (notification.ClearBefore) {
				this.Notifications = string.Empty;
			}

			this.Notifications = notification.Message + Environment.NewLine + this.Notifications;
		}
	}
}
