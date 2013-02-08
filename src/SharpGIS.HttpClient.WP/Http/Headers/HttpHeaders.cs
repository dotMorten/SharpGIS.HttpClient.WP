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
		// Summary:
		//     Adds the specified header and its values into the System.Net.Http.Headers.HttpHeaders
		//     collection.
		//
		// Parameters:
		//   name:
		//     The header to add to the collection.
		//
		//   values:
		//     A list of header values to add to the collection.
		public void Add(string name, IEnumerable<string> values)
		{
			m_headers[name] = string.Join("; ", values);
		}
		//
		// Summary:
		//     Adds the specified header and its value into the System.Net.Http.Headers.HttpHeaders
		//     collection.
		//
		// Parameters:
		//   name:
		//     The header to add to the collection.
		//
		//   value:
		//     The content of the header.
		public void Add(string name, string value)
		{
			m_headers[name] = value;
		}

		/// <summary>
		/// Initializes a new instance of the System.Net.Http.Headers.HttpHeaders class.
		/// </summary>
		public HttpHeaders()
		{
			m_headers = new WebHeaderCollection();
		}
		internal IEnumerable<KeyValuePair<string,string>> InternalHeaders
		{
			get
			{
				foreach (var key in m_headers.AllKeys)
					yield return new KeyValuePair<string, string>(key, m_headers[key]);
			}
		}

		public IEnumerator<KeyValuePair<string, IEnumerable<string>>> GetEnumerator()
		{
			foreach (var header in m_headers.AllKeys)
			{
				yield return new KeyValuePair<string, IEnumerable<string>>(header,
					m_headers[header].Split(new string[] { "; " }, StringSplitOptions.None));
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
				return header.Split(new string[] { "; " }, StringSplitOptions.None);
			return null;
		}

		public bool Contains(string name)
		{
			return m_headers[name] != null;
		}
	}
}
