using SharpGIS.HttpClient.WP.GZip;
using System.IO;
using System.Threading.Tasks;

namespace System.Net.Http
{
	/// <summary>
	/// The default message handler used by System.Net.Http.HttpClient.
	/// </summary>
	public class HttpClientHandler : HttpMessageHandler
	{
		public HttpClientHandler() : base()
		{
			SupportsAutomaticDecompression = true;
			AllowAutoRedirect = true;
		}

		/// <summary>
		/// Sends the async.
		/// </summary>
		/// <param name="request">The request.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <returns></returns>
		protected internal override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, Threading.CancellationToken cancellationToken)
		{
			TaskCompletionSource<HttpResponseMessage> tcs = new TaskCompletionSource<HttpResponseMessage>();
			if (cancellationToken.IsCancellationRequested)
			{
				tcs.SetCanceled();
			}
			else
			{
				HttpWebRequest webRequest = null;
				if (this.AutomaticDecompression == DecompressionMethods.GZip)
					webRequest = new GZipHttpWebRequest(request.RequestUri);
				else
					webRequest = WebRequest.CreateHttp(request.RequestUri);
				webRequest.Method = request.Method.Method;
				if (webRequest.SupportsCookieContainer)
					webRequest.CookieContainer = this.CookieContainer;
				webRequest.AllowAutoRedirect = this.AllowAutoRedirect;
				webRequest.Credentials = this.Credentials;
				webRequest.UseDefaultCredentials = this.UseDefaultCredentials;

				var beginGetResponseDelegate = new AsyncCallback(delegate(IAsyncResult asynchronousResult2)
				{
					HttpWebRequest req2 = (HttpWebRequest)asynchronousResult2.AsyncState;

					if (req2.HaveResponse)
					{
						try
						{
							WebResponse response = req2.EndGetResponse(asynchronousResult2);
							tcs.SetResult(new HttpResponseMessage(response, request));
						}
						catch (Exception exception)
						{
							tcs.SetException(exception);
						}
					}

				});

				if (request.Method == HttpMethod.Get || request.Method == HttpMethod.Head)
				{
					webRequest.BeginGetResponse(beginGetResponseDelegate, webRequest);
				}
				else
				{
					webRequest.BeginGetRequestStream(new AsyncCallback(async delegate(IAsyncResult asynchronousResult)
					{
						HttpWebRequest req = (HttpWebRequest)asynchronousResult.AsyncState;

						if (cancellationToken.IsCancellationRequested)
							tcs.SetCanceled();
						else
						{
							if (request.Content != null)
							{
								Stream postStream = null;
								try
								{
									postStream = req.EndGetRequestStream(asynchronousResult);
								}
								catch (Exception ex)
								{
									tcs.SetException(ex);
									return;
								}
								StreamWriter writer = new StreamWriter(postStream);
								writer.Write(await request.Content.ReadAsByteArrayAsync());
								if (cancellationToken.IsCancellationRequested)
								{
									tcs.SetCanceled();
									return;
								}
								writer.Flush();
								postStream.Close();
							}

							req.BeginGetResponse(beginGetResponseDelegate, req);
						}
					}), webRequest);
				}
			}
			return tcs.Task;
		}

		/// <summary>
		/// Gets or sets a value that indicates whether the handler should follow redirection
		/// responses.
		/// </summary>
		/// <value>
		/// Returns System.Boolean.true if the if the handler should follow redirection
		/// responses; otherwise false. The default value is true.
		/// </value>
		public bool AllowAutoRedirect { get; set; }

		/// <summary>
		/// Gets or sets the type of decompression method used by the handler for automatic
		/// decompression of the HTTP content response.
		/// </summary>
		/// <value>
		/// Returns System.Net.DecompressionMethods.The automatic decompression method
		/// used by the handler. The default value is System.Net.DecompressionMethods.None.
		/// </value>
		public DecompressionMethods AutomaticDecompression { get; set; }

		/// <summary>
		///  Gets or sets the collection of security certificates that are associated
		///  with this handler.
		/// </summary>
		/// <value>
		/// Returns System.Net.Http.ClientCertificateOption.The collection of security
		/// certificates associated with this handler.
		/// </value>
		//public ClientCertificateOption ClientCertificateOptions { get; set; } //Not supported by WinPhone
 
		/// <summary>
		/// Gets or sets the cookie container used to store server cookies by the handler.
		/// </summary>
		/// <value>
		/// Returns System.Net.CookieContainer.The cookie container used to store server
		/// cookies by the handler.
		/// </value>
		public CookieContainer CookieContainer { get; set; }

		/// <summary>
		/// Gets or sets authentication information used by this handler.
		/// </summary>
		/// <value>
		/// Returns System.Net.ICredentials.The authentication credentials associated
		/// with the handler. The default is null. 
		/// </value>
		public ICredentials Credentials { get; set; }

		//
		// Summary:
		//     Gets or sets the maximum number of redirects that the handler follows.
		//
		// Returns:
		//     Returns System.Int32.The maximum number of redirection responses that the
		//     handler follows. The default value is 50.
		public int MaxAutomaticRedirections { get; set; }
		//
		// Summary:
		//     Gets or sets the maximum request content buffer size used by the handler.
		//
		// Returns:
		//     Returns System.Int32.The maximum request content buffer size in bytes. The
		//     default value is 65,536 bytes.
		public long MaxRequestContentBufferSize { get; set; }
		//
		// Summary:
		//     Gets or sets a value that indicates whether the handler sends an Authorization
		//     header with the request.
		//
		// Returns:
		//     Returns System.Boolean.true for the handler to send an HTTP Authorization
		//     header with requests after authentication has taken place; otherwise, false.
		//     The default is false.
		public bool PreAuthenticate { get; set; }
		//
		// Summary:
		//     Gets or sets proxy information used by the handler.
		//
		// Returns:
		//     Returns System.Net.IWebProxy.The proxy information used by the handler. The
		//     default value is null.
		//public IWebProxy Proxy { get; set; }
		//
		// Summary:
		//     Gets a value that indicates whether the handler supports automatic response
		//     content decompression.
		//
		// Returns:
		//     Returns System.Boolean.true if the if the handler supports automatic response
		//     content decompression; otherwise false. The default value is true.
		public virtual bool SupportsAutomaticDecompression { get; private set; }
		//
		// Summary:
		//     Gets a value that indicates whether the handler supports proxy settings.
		//
		// Returns:
		//     Returns System.Boolean.true if the if the handler supports proxy settings;
		//     otherwise false. The default value is true.
		public virtual bool SupportsProxy { get; private set; }
		//
		// Summary:
		//     Gets a value that indicates whether the handler supports configuration settings
		//     for the System.Net.Http.HttpClientHandler.AllowAutoRedirect and System.Net.Http.HttpClientHandler.MaxAutomaticRedirections
		//     properties.
		//
		// Returns:
		//     Returns System.Boolean.true if the if the handler supports configuration
		//     settings for the System.Net.Http.HttpClientHandler.AllowAutoRedirect and
		//     System.Net.Http.HttpClientHandler.MaxAutomaticRedirections properties; otherwise
		//     false. The default value is true.
		public virtual bool SupportsRedirectConfiguration { get; private set; }
		//
		// Summary:
		//     Gets or sets a value that indicates whether the handler uses the System.Net.Http.HttpClientHandler.CookieContainer
		//     property to store server cookies and uses these cookies when sending requests.
		//
		// Returns:
		//     Returns System.Boolean.true if the if the handler supports uses the System.Net.Http.HttpClientHandler.CookieContainer
		//     property to store server cookies and uses these cookies when sending requests;
		//     otherwise false. The default value is true.
		public bool UseCookies { get; set; }
		//
		// Summary:
		//     Gets or sets a value that controls whether default credentials are sent with
		//     requests by the handler.
		//
		// Returns:
		//     Returns System.Boolean.true if the default credentials are used; otherwise
		//     false. The default value is false.
		public bool UseDefaultCredentials { get; set; }
		//
		// Summary:
		//     Gets or sets a value that indicates whether the handler uses a proxy for
		//     requests.
		//
		// Returns:
		//     Returns System.Boolean.true if the handler should use a proxy for requests;
		//     otherwise false. The default value is true.
		public bool UseProxy { get; set; }

		// Summary:
		//     Releases the unmanaged resources used by the System.Net.Http.HttpClientHandler
		//     and optionally disposes of the managed resources.
		//
		// Parameters:
		//   disposing:
		//     true to release both managed and unmanaged resources; false to releases only
		//     unmanaged resources.
		protected override void Dispose(bool disposing)
		{

		}
	}
}
