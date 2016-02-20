
using System;
using System.Globalization;

namespace Logos.Utility
{
	/// <summary>
	/// Provides methods for manipulating dates.
	/// </summary>
	/// <remarks>See <a href="http://code.logos.com/blog/2009/04/datetime_and_iso8601.html">DateTime and ISO8601</a>.</remarks>
	public static class DateTimeUtility
	{
		/// <summary>
		/// Converts the specified ISO 8601 representation of a date and time
		/// to its DateTime equivalent.
		/// </summary>
		/// <param name="value">The ISO 8601 string representation to parse.</param>
		/// <returns>The DateTime equivalent.</returns>
		public static DateTime ParseIso8601(string value)
		{
			return DateTime.ParseExact(value, Iso8601Format, CultureInfo.InvariantCulture,
				DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
		}

		/// <summary>
		/// Formats the date in the standard ISO 8601 format.
		/// </summary>
		/// <param name="value">The date to format.</param>
		/// <returns>The formatted date.</returns>
		public static string ToIso8601(this DateTime value)
		{
			return value.ToUniversalTime().ToString(Iso8601Format, CultureInfo.InvariantCulture);
		}

		/// <summary>
		/// Formats date as Epoc
		/// </summary>
		/// <returns>The epoc.</returns>
		/// <param name="value">Value.</param>
		public static string ToEpocDate(this DateTime value){
			var start = new DateTime (1970, 1, 1);
			var dayDiff = DateTime.Today - start;
			var seconds = dayDiff.Days * 24 * 60 * 60;
			return seconds.ToString ();
		}

		/// <summary>
		/// The ISO 8601 format string.
		/// </summary>
		public const string Iso8601Format = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'";

	}
}
