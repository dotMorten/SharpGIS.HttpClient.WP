using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Net.Http.Headers
{
	/// <summary>
	///  A collection of headers and their values as defined in RFC 2616.
	/// </summary>
	public class HttpHeaders : IEnumerable<KeyValuePair<String, IEnumerable<String>>>, IEnumerable
	{
		private WebHeaderCollection m_headers;

		/// <summary>
		/// Initializes a new instance of the System.Net.Http.Headers.HttpHeaders class.
		/// </summary>
		/// <param name="headers"></param>
		internal HttpHeaders(WebHeaderCollection headers)
		{
			m_headers = headers;
		}

		/// <summary>
		/// Initializes a new instance of the System.Net.Http.Headers.HttpHeaders class.
		/// </summary>
		public HttpHeaders()
		{
			m_headers = new WebHeaderCollection();
		}

		public IEnumerator<KeyValuePair<string, IEnumerable<string>>> GetEnumerator()
		{
			foreach (var header in m_headers.AllKeys)
			{
				yield return new KeyValuePair<string, IEnumerable<string>>(header,
					m_headers[header].Split(new char[] { ',' }));
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public IEnumerable<string> GetValues(string name)
		{
			var header = m_headers[name];
			if (header != null)
				return header.Split(new char[] { ',' });
			return null;
		}

		public bool Contains(string name)
		{
			return m_headers[name] != null;
		}
	}
}
