using GestAssoc.Common.Event;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;

namespace GestAssoc.Common.Utility
{
	public static class NotificationHelper
	{
		public static void WriteLog(string message) {
			ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IEventAggregator>()
				.GetEvent<LogEvent>()
				.Publish(new LogEntry(message));				
		}

		public static void WriteLogs(List<string> messagesList) {
			var message = string.Join(" ", messagesList);
			WriteLog(message);
		}

		public static void ShowError(Exception ex) {
			ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IEventAggregator>()
				.GetEvent<UserNotificationEvent>()
				.Publish(
					new UserNotification() { Message=ex.Message, Titre=Properties.Resources.Titre_Erreur}
				);
		}

		public static void ShowUserNotification(string message) {
			ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IEventAggregator>()
				.GetEvent<UserNotificationEvent>()
				.Publish(
					new UserNotification() { Message=message, Titre=Properties.Resources.Titre_Info}
				);
		}
	}
}
