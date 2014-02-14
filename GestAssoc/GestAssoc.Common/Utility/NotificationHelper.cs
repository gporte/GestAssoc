﻿using GestAssoc.Common.Event;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

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
	}
}