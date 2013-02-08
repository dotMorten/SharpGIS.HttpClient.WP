using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Net.Http
{
	/// <summary>
	/// A container for name/value tuples encoded using application/x-www-form-urlencoded
	/// MIME type.
	/// </summary>
	public class FormUrlEncodedContent : ByteArrayContent
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FormUrlEncodedContent" /> class
		///  with a specific collection of name/value pairs.
		/// </summary>
		/// <param name="nameValueCollection">A collection of name/value pairs.</param>
		public FormUrlEncodedContent(IEnumerable<KeyValuePair<string, string>> nameValueCollection)
			: base(FormDataToByteArray(nameValueCollection))
		{
			Headers.Add("Content-Type", new string[] { "application/x-www-form-urlencoded" });
		}

		private static byte[] FormDataToByteArray(IEnumerable<KeyValuePair<string, string>> nameValueCollection)
		{
			StringBuilder sb = new StringBuilder();
			foreach (var nameValue in nameValueCollection)
			{
				if (sb.Length > 0)
					sb.Append('&');
				sb.Append(nameValue.Key);
				sb.Append('=');
				sb.Append(Uri.EscapeDataString(nameValue.Value));
			}
			return UTF8Encoding.UTF8.GetBytes(sb.ToString());
		}
	}
}
