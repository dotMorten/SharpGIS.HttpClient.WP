using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http
{
	/// <summary>
	/// A base type for HTTP message handlers.
	/// </summary>
	public abstract class HttpMessageHandler
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="HttpMessageHandler" /> class.
		/// </summary>
		protected HttpMessageHandler()
		{

		}

		/// <summary>
		/// Releases the unmanaged resources and disposes of the managed resources used
		/// by the System.Net.Http.HttpMessageHandler.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
		}

		/// <summary>
		/// Releases the unmanaged resources used by the System.Net.Http.HttpMessageHandler
		/// and optionally disposes of the managed resources.
		/// </summary>
		/// <param name="disposing"> 
		/// <c>true</c> to release both managed and unmanaged resources;
		/// <c>false</c> to release only unmanaged resources.</param>
		protected virtual void Dispose(bool disposing)
		{

		}
		
		/// <summary>
		///  Send an HTTP request as an asynchronous operation.
		/// </summary>
		/// <param name="request">The HTTP request message to send.</param>
		/// <param name="cancellationToken">The cancellation token to cancel operation.</param>
		/// <returns>
		///  Returns System.Threading.Tasks.Task<TResult>.The task object representing
		///  the asynchronous operation.
		///  </returns>
		//   System.ArgumentNullException:
		protected internal abstract Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken);
	}
}
