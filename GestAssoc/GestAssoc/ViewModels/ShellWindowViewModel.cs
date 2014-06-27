using GestAssoc.Common.Commands;
using GestAssoc.Common.Event;
using GestAssoc.Common.Utility;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;

namespace GestAssoc.ViewModels
{
	public class ShellWindowViewModel : BindableBase
	{
		public InteractionRequest<INotification> RqNotifError { get; private set; }
		
		#region Commands
		public ExitCommand ExitCmd { get; set; }
		#endregion

		#region LogEntries Property
		private string _logEntries;
		public string LogEntries {
			get { return this._logEntries; }
			set {
				this.SetProperty(ref this._logEntries, value);
			}
		}
		#endregion

		private IEventAggregator _aggregator;

		public ShellWindowViewModel() {
			this._aggregator = ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IEventAggregator>();

			this.RqNotifError = new InteractionRequest<INotification>();

			this._aggregator.GetEvent<LogEvent>().Subscribe(this.WriteLog);
			this._aggregator.GetEvent<UserNotificationEvent>().Subscribe(this.ShowUserNotification);

			this.ExitCmd = new ExitCommand();
		}

		private void ShowUserNotification(UserNotification notif) {
			this.RqNotifError.Raise(new Notification() { Content = notif.Message, Title = notif.Titre });
		}

		private void WriteLog(LogEntry entry) {
			this.LogEntries = entry.FormattedMessage + Environment.NewLine + this.LogEntries;
		}
	}
}
