
namespace GestAssoc.Common.Utility
{
	public class UserNotification
	{
		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <value>
		/// The message.
		/// </value>
		public string Message { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [clear before].
		/// </summary>
		/// <value>
		///   <c>true</c> if [clear before]; otherwise, <c>false</c>.
		/// </value>
		public bool ClearBefore { get; set; }
		
		/// <summary>
		/// Initializes a new instance of the <see cref="UserNotification"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="clearBefore">if set to <c>true</c> [clear before].</param>
		public UserNotification(string message, bool clearBefore) {
			this.Message = message;
			this.ClearBefore = clearBefore;
		}
	}
}
