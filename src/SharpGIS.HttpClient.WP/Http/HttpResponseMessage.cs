using System.Net.Http.Headers;

namespace System.Net.Http
{
	/// <summary>
	/// Represents a HTTP response message.
	/// </summary>
	public class HttpResponseMessage : IDisposable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="HttpResponseMessage" /> class.
		/// </summary>
		public HttpResponseMessage() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="HttpResponseMessage" /> class
		/// with a specific System.Net.Http.HttpResponseMessage.StatusCode.</summary>
		/// <param name="statusCode">The status code.</param>
		public HttpResponseMessage(HttpStatusCode statusCode)
		{
			IsSuccessStatusCode = statusCode == HttpStatusCode.OK;
		}

		internal HttpResponseMessage(WebResponse response, HttpRequestMessage request)
		{
			var stream = response.GetResponseStream();
			if (stream != null)
				Content = new StreamContent(stream) { Headers = new HttpContentHeaders(response.Headers) };
			if (response.SupportsHeaders)
			{
				Headers = new HttpResponseHeaders(response.Headers);
			}
			if (response is HttpWebResponse)
			{
				var httpResponse = response as HttpWebResponse;
				StatusCode = httpResponse.StatusCode;
				IsSuccessStatusCode = ((int)StatusCode >= 200 && (int)StatusCode <= 299);
				ReasonPhrase = httpResponse.StatusDescription;
			}
			RequestMessage = request;
		}

		/// <summary>
		/// Ensures the success status code.
		/// </summary>
		/// <returns></returns>
		/// <exception cref="System.Net.Http.HttpRequestException"></exception>
		public HttpResponseMessage EnsureSuccessStatusCode()
		{
			if (!IsSuccessStatusCode)
				throw new HttpRequestException(ReasonPhrase);
			return this;
		}

		/// <summary>
		/// Gets the collection of HTTP response headers.
		/// </summary>
		/// <value>
		/// Returns <see cref="System.Net.Http.Headers.HttpResponseHeaders"/>.
		/// The collection of HTTP response headers.
		/// </value>
		public HttpResponseHeaders Headers { get; private set; }

		/// <summary>
		/// Gets a value that indicates if the HTTP response was successful.
		/// </summary>
		/// <value>
		/// Returns System.Boolean.A value that indicates if the HTTP response was successful.
		/// true if System.Net.Http.HttpResponseMessage.StatusCode was in the range 200-299;
		/// otherwise false.
		/// </value>
		public bool IsSuccessStatusCode { get; private set; }

		/// <summary>
		/// Gets or sets the content of a HTTP response message.
		/// </summary>
		/// <value>
		///  Returns <see cref="HttpContent" />.The content of the HTTP response message.
		/// </value>
		public HttpContent Content { get; set; }

		/// <summary>
		/// Gets or sets the reason phrase which typically is sent by servers together
		/// with the status code.
		/// </summary>
		/// <value>
		/// Returns <see cref="String"/>. The reason phrase sent by the server.
		/// </value>
		public string ReasonPhrase { get; set; }

		/// <summary>
		/// Gets or sets the request message which led to this response message.
		/// </summary>
		/// <value>
		/// Returns System.Net.Http.HttpRequestMessage.The request message which led
		/// to this response message.
		/// </value>
		public HttpRequestMessage RequestMessage { get; set; }

		/// <summary>
		/// Gets or sets the status code of the HTTP response.
		/// </summary>
		/// <value>
		/// Returns System.Net.HttpStatusCode.The status code of the HTTP response.
		/// </value>
		public HttpStatusCode StatusCode { get; set; }

		public void Dispose()
		{
			Content.Dispose();
		}
	}
}
