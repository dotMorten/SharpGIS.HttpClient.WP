using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace System.Net.Http
{
	/// <summary>
	/// Represents a HTTP request message.
	/// </summary>
	public class HttpRequestMessage : IDisposable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="HttpRequestMessage" /> class.
		/// </summary>
		public HttpRequestMessage() : this(HttpMethod.Get, (Uri)null)
		{ }
		/// <summary>
		/// Initializes a new instance of the <see cref="HttpRequestMessage" /> class
		/// with an HTTP method and a request System.Uri.
		/// </summary>
		/// <param name="method">The HTTP method.</param>
		/// <param name="requestUri">A string that represents the request System.Uri.</param>
		public HttpRequestMessage(HttpMethod method, string requestUri) : this(method, new Uri(requestUri))
		{
			
		}
   
		/// <summary>
		/// Initializes a new instance of the <see cref="HttpRequestMessage" /> class
		/// with an HTTP method and a request System.Uri.
		/// </summary>
		/// <param name="method">The HTTP method.</param>
		/// <param name="requestUri">The System.Uri to request.</param>
		public HttpRequestMessage(HttpMethod method, Uri requestUri)
		{
			RequestUri = requestUri;
			Properties = new Dictionary<string, object>();
			Version = new Version("1.1");
			Method = method;
		}

		public void Dispose()
		{
			if (Content != null)
				Content.Dispose();
		}

		/// <summary>
		/// Gets or sets the contents of the HTTP message.
		/// </summary>
		/// <value>
		/// Returns System.Net.Http.HttpContent.The content of a message
		/// </value>
		public HttpContent Content { get; set; }

		/// <summary>
		/// Gets the collection of HTTP request headers.
		/// </summary>
		/// <value>
		/// Returns System.Net.Http.Headers.HttpRequestHeaders.The collection of HTTP
		/// request headers.</value>
		public HttpRequestHeaders Headers { get; private set; }

		/// <summary>
		/// Gets or sets the HTTP method used by the HTTP request message.
		/// </summary>
		/// <value>
		/// Returns System.Net.Http.HttpMethod.The HTTP method used by the request message.
		/// The default is the GET method.
		/// </value>
		public HttpMethod Method { get; set; }

		/// <summary>
		/// Gets or sets the System.Uri used for the HTTP request.
		/// </summary>
		/// <value>
		/// Returns System.Uri.The System.Uri used for the HTTP request.
		/// </value>
		public Uri RequestUri { get; set; }

		/// <summary>
		/// Gets or sets the HTTP message version.
		/// </summary>
		/// <value>
		/// Returns System.Version.The HTTP message version. The default is 1.1.
		/// </value>
		public Version Version { get; set; }

		/// <summary>
		/// Gets a set of properties for the HTTP request.
		/// </summary>
		/// <value>
		/// Returns System.Collections.Generic.IDictionary<TKey,TValue>.
		/// </value>
		public IDictionary<string, object> Properties { get; private set; }
	}
}
