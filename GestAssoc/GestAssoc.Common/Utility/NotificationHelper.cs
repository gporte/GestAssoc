using GestAssoc.Common.Event;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System.Collections.Generic;

namespace GestAssoc.Common.Utility
{
	public static class NotificationHelper
	{
		public static void WriteNotification(string message, bool clearBefore = false) {
			ServiceLocator
				.Current.GetInstance<IUnityContainer>()
				.Resolve<IEventAggregator>()
				.GetEvent<NotificationEvent>()
				.Publish(new UserNotification(message, clearBefore));				
		}

		public static void WriteNotificationList(List<string> messagesList, bool clearBefore = false) {
			var message = string.Join(" ", messagesList);
			WriteNotification(message, clearBefore);
		}
	}
}
