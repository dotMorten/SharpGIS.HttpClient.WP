using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http
{
	/// <summary>
	/// The base type for System.Net.Http.HttpClient and other message originators.
	/// </summary>
	public class HttpMessageInvoker : IDisposable
	{
		private HttpMessageHandler m_handler;
		private bool m_disposeHandler;
		// Summary:
		//     Initializes an instance of a System.Net.Http.HttpMessageInvoker class with
		//     a specific System.Net.Http.HttpMessageHandler.
		//
		// Parameters:
		//   handler:
		//     The System.Net.Http.HttpMessageHandler responsible for processing the HTTP
		//     response messages.
		public HttpMessageInvoker(HttpMessageHandler handler)
			: this(handler, false)
		{

		}
		//
		// Summary:
		//     Initializes an instance of a System.Net.Http.HttpMessageInvoker class with
		//     a specific System.Net.Http.HttpMessageHandler.
		//
		// Parameters:
		//   handler:
		//     The System.Net.Http.HttpMessageHandler responsible for processing the HTTP
		//     response messages.
		//
		//   disposeHandler:
		//     true if the inner handler should be disposed of by Dispose(),false if you
		//     intend to reuse the inner handler.
		public HttpMessageInvoker(HttpMessageHandler handler, bool disposeHandler)
		{
			if (handler == null)
				throw new ArgumentNullException("handler");
			m_handler = handler;
			m_disposeHandler = disposeHandler;
		}


		// Summary:
		//     Releases the unmanaged resources and disposes of the managed resources used
		//     by the System.Net.Http.HttpMessageInvoker.
		public void Dispose()
		{
			Dispose(true);
		}
		//
		// Summary:
		//     Releases the unmanaged resources used by the System.Net.Http.HttpMessageInvoker
		//     and optionally disposes of the managed resources.
		//
		// Parameters:
		//   disposing:
		//     true to release both managed and unmanaged resources; false to releases only
		//     unmanaged resources.
		protected virtual void Dispose(bool disposing)
		{
			if (m_disposeHandler)
				m_handler.Dispose();
		}
		//
		// Summary:
		//     Send an HTTP request as an asynchronous operation.
		//
		// Parameters:
		//   request:
		//     The HTTP request message to send.
		//
		//   cancellationToken:
		//     The cancellation token to cancel operation.
		//
		// Returns:
		//     Returns System.Threading.Tasks.Task<TResult>.The task object representing
		//     the asynchronous operation.
		//
		// Exceptions:
		//   System.ArgumentNullException:
		//     The request was null.
		public virtual Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			if (request == null)
				throw new ArgumentNullException("request", "The request was null.");
			return m_handler.SendAsync(request, cancellationToken);
		}
	}
}
