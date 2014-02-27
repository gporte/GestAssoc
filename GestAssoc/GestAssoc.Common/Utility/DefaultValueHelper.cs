using System;

namespace GestAssoc.Common.Utility
{
	public static class DefaultValueHelper
	{
		/// <summary>
		/// DateTime minimum pour SQL.
		/// </summary>
		public static DateTime DateTimeSQLMinValue {
			get { return new DateTime(1753, 1, 1); }
		}
	}
}
