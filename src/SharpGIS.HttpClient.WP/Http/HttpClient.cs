using SharpGIS.HttpClient.WP8.GZip;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http
{
	/// <summary>
	/// Provides a base class for sending HTTP requests and receiving HTTP responses
	/// from a resource identified by a URI.
	/// </summary>
	public class HttpClient : HttpMessageInvoker
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="HttpClient" /> class.
		/// </summary>
		public HttpClient() : this(null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="HttpClient" /> class
		/// with a specific handler.
		/// </summary>
		/// <param name="handler">The HTTP handler stack to use for sending requests.</param>
		/// <remarks>
		/// If null is specified for handler parameter, the <see cref="HttpClientHandler"/> 
		/// is used as transport handler.
		/// </remarks>
		public HttpClient(HttpMessageHandler handler)
			: base(handler ?? new HttpClientHandler(), false)
		{
		}

		public Task<HttpResponseMessage> GetAsync(string requestUri)
		{
			return GetAsync(requestUri, System.Threading.CancellationToken.None);
		}

		public Task<HttpResponseMessage> GetAsync(Uri requestUri)
		{
			return GetAsync(requestUri, System.Threading.CancellationToken.None);
		}

		public Task<HttpResponseMessage> GetAsync(string requestUri, System.Threading.CancellationToken token)
		{
			if (requestUri == null)
				throw new ArgumentNullException("requestUri");
			return GetAsync(new Uri(requestUri), token);
		}

		public Task<HttpResponseMessage> GetAsync(Uri requestUri, System.Threading.CancellationToken token)
		{
			return GetAsync(requestUri, HttpCompletionOption.ResponseContentRead, token);
		}

		/// <summary>
		/// Send a GET request to the specified Uri with an HTTP completion option and
		/// a cancellation token as an asynchronous operation.
		/// </summary>
		/// <param name="requestUri">The Uri the request is sent to.</param>
		/// <param name="completionOption">
		/// An HTTP completion option value that indicates when the operation should
		/// be considered completed.
		/// </param>
		/// <param name="cancellationToken">
		///  A cancellation token that can be used by other objects or threads to receive
		///  notice of cancellation.
		/// </param>
		/// <returns>
		/// Returns System.Threading.Tasks.Task<TResult>.The task object representing
		/// the asynchronous operation.
		/// </returns>
		/// <exception cref="System.ArgumentNullException">The requestUri was null.</exception>
		public Task<HttpResponseMessage> GetAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken)
		{
			var req = new HttpRequestMessage() { RequestUri = requestUri, Method = HttpMethod.Get };
			return SendAsync(req, completionOption, cancellationToken);
		}

		/// <summary>
		/// Send a GET request to the specified Uri and return the response body as a
		/// string in an asynchronous operation.
		/// </summary>
		/// <param name="requestUri">The Uri the request is sent to.</param>
		/// <returns>
		/// Returns System.Threading.Tasks.Task&lt;TResult&gt;.The task object representing
		/// the asynchronous operation.
		/// </returns>
		/// <exception cref="System.ArgumentNullException">The requestUri was null.</exception>
		public Task<string> GetStringAsync(string requestUri)
		{
			if (requestUri == null)
				throw new ArgumentNullException("requestUri", "The requestUri was null.");
			return GetStringAsync(new Uri(requestUri));
		}

		/// <summary>
		/// Send a GET request to the specified Uri and return the response body as a
		/// string in an asynchronous operation.
		/// </summary>
		/// <param name="requestUri">The Uri the request is sent to.</param>
		/// <returns>
		/// Returns System.Threading.Tasks.Task&lt;TResult&gt;.The task object representing
		/// the asynchronous operation.
		/// </returns>
		/// <exception cref="System.ArgumentNullException">The requestUri was null.</exception>
		public async Task<string> GetStringAsync(Uri requestUri)
		{
			//TODO: There's a lot of context switch here that could be avoided
			var response = await GetAsync(requestUri);
			return await response.Content.ReadAsStringAsync();
		}

		/// <summary>
		/// Send a POST request to the specified Uri as an asynchronous operation.
		/// </summary>
		/// <param name="requestUri">T The Uri the request is sent to.</param>
		/// <param name="content">The HTTP request content sent to the server.</param>
		/// <returns>
		///  Returns System.Threading.Tasks.Task&lt;TResult&gt;.The task object representing
		///  the asynchronous operation.
		///  </returns>
		/// <exception cref="System.ArgumentNullException">The requestUri was null.</exception>
		public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
		{
			return PostAsync(requestUri, content, CancellationToken.None);
		}

		/// <summary>
		/// Send a POST request with a cancellation token as an asynchronous operation.
		/// </summary>
		/// <param name="requestUri">he Uri the request is sent to.</param>
		/// <param name="content">The HTTP request content sent to the server.</param>
		/// <returns>
		///  Returns System.Threading.Tasks.Task&lt;TResult&gt;.The task object representing
		/// the asynchronous operation.
		/// </returns>
		/// <exception cref="System.ArgumentNullException">The requestUri was null.</exception>
		public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content)
		{
			return PostAsync(requestUri, content, CancellationToken.None);
		}

		/// <summary>
		/// Send a POST request with a cancellation token as an asynchronous operation.
		/// </summary>
		/// <param name="requestUri">he Uri the request is sent to.</param>
		/// <param name="content">The HTTP request content sent to the server.</param>
		/// <param name="cancellationToken">
		/// A cancellation token that can be used by other objects or threads to receiv
		/// notice of cancellation.
		/// </param>
		/// <returns>
		///  Returns System.Threading.Tasks.Task&lt;TResult&gt;.The task object representing
		/// the asynchronous operation.
		/// </returns>
		/// <exception cref="System.ArgumentNullException">The requestUri was null.</exception>
		public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content, CancellationToken cancellationToken)
		{
			if (requestUri == null)
				throw new ArgumentNullException("requestUri", "The requestUri was null.");
			return PostAsync(new Uri(requestUri), content, cancellationToken);
		}
		
		/// <summary>
		/// Send a POST request with a cancellation token as an asynchronous operation.
		/// </summary>
		/// <param name="requestUri">he Uri the request is sent to.</param>
		/// <param name="content">The HTTP request content sent to the server.</param>
		/// <param name="cancellationToken">
		/// A cancellation token that can be used by other objects or threads to receiv
		/// notice of cancellation.
		/// </param>
		/// <returns>
		///  Returns System.Threading.Tasks.Task&lt;TResult&gt;.The task object representing
		/// the asynchronous operation.
		/// </returns>
		/// <exception cref="System.ArgumentNullException">The requestUri was null.</exception>
		public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
		{
			if (requestUri == null)
				throw new ArgumentNullException("requestUri", "The requestUri was null.");
			var req = new HttpRequestMessage() { RequestUri = requestUri, Method = HttpMethod.Post, Content = content };
			return SendAsync(req, cancellationToken);
		}

		/// <summary>
		/// Send an HTTP request as an asynchronous operation.
		/// </summary>
		/// <param name="request">The HTTP request message to send.</param>
		/// <returns>
		/// Returns System.Threading.Tasks.Task&lt;TResult&gt;.The task object representing
		/// the asynchronous operation.
		/// </returns>
		/// <exception cref="System.ArgumentNullException">The request was null.</exception>
		/// <exception cref="System.InvalidOperationException">The request message was already sent by the 
		/// <see cref="HttpClient"/> instance.</exception>
		public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
		{
			return SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None);
		}

		/// <summary>
		/// Send an HTTP request as an asynchronous operation.
		/// </summary>
		/// <param name="request">The HTTP request message to send.</param>
		/// <param name="cancellationToken">The cancellation token to cancel operation.</param>
		/// <returns>
		/// Returns System.Threading.Tasks.Task&lt;TResult&gt;.The task object representing
		/// the asynchronous operation.
		/// </returns>
		/// <exception cref="System.ArgumentNullException">The request was null.</exception>
		/// <exception cref="System.InvalidOperationException">The request message was already sent by the 
		/// <see cref="HttpClient"/> instance.</exception>
		public override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			return base.SendAsync(request, cancellationToken);
		}

		/// <summary>
		/// Send an HTTP request as an asynchronous operation.
		/// </summary>
		/// <param name="request">The HTTP request message to send.</param>
		/// <param name="completionOption">When the operation should complete
		/// (as soon as a response is available or after reading the whole response content).</param>
		/// <returns>
		/// Returns System.Threading.Tasks.Task&lt;TResult&gt;.The task object representing
		/// the asynchronous operation.
		/// </returns>
		/// <exception cref="System.ArgumentNullException">The request was null.</exception>
		/// <exception cref="System.InvalidOperationException">The request message was already sent by the 
		/// <see cref="HttpClient"/> instance.</exception>
		public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption)
		{
			return SendAsync(request, completionOption, CancellationToken.None);
		}
		
		/// <summary>
		/// Send an HTTP request as an asynchronous operation.
		/// </summary>
		/// <param name="request">The HTTP request message to send.</param>
		/// <param name="completionOption">When the operation should complete
		/// (as soon as a response is available or after reading the whole response content).</param>
		/// <param name="cancellationToken">The cancellation token to cancel operation.</param>
		/// <returns>
		/// Returns System.Threading.Tasks.Task&lt;TResult&gt;.The task object representing
		/// the asynchronous operation.
		/// </returns>
		/// <exception cref="System.ArgumentNullException">The request was null.</exception>
		/// <exception cref="System.InvalidOperationException">The request message was already sent by the 
		/// <see cref="HttpClient"/> instance.</exception>
		public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption, CancellationToken cancellationToken)
		{
			return SendAsync(request, cancellationToken);
		}
	}
}
