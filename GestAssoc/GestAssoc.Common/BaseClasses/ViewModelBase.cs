using GestAssoc.Common.Utility;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Prism.Mvvm;

namespace GestAssoc.Common.BaseClasses
{
	public abstract class ViewModelBase : BindableBase
	{
		protected ViewModelBase() {
			this.NotificationRequest = new InteractionRequest<INotification>();
		}
		
		#region Notifications
		public InteractionRequest<INotification> NotificationRequest { get; private set; }

		protected void RaiseNotification(string message) {
			var notif = new Notification()
			{
				Content = message,
				Title = "test de notif"
			};

			this.NotificationRequest.Raise(notif, n => { this.callback(n); });
		}

		private void callback(INotification notif) {
			NotificationHelper.WriteNotification("callback notif : " + notif.Title);
		}
		#endregion
	}
}
