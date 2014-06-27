
using System;
namespace GestAssoc.Common.Utility
{
	public class LogEntry
	{
		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <value>
		/// The message.
		/// </value>
		public string Message { get; set; }
		/// <summary>
		/// Get or set the timestamp of the message.
		/// </summary>
		/// <value>
		/// Timestamp of the message.
		/// </value>
		public DateTime TimestampMessage { get; set; }

		/// <summary>
		/// Get the message formatted.
		/// </summary>
		/// <value>
		/// The message formatted.
		/// </value>
		public string FormattedMessage {
			get {
				return string.Format(
					"{0} - {1}", 
					this.TimestampMessage.ToString("yyyy-MM-ddTHH:mm:ss.fff"), 
					this.Message
				);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="LogEntry"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		public LogEntry(string message) {
			this.TimestampMessage = DateTime.Now;
			this.Message = message;
		}
	}
}
