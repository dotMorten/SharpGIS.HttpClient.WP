using System.IO;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace System.Net.Http
{
	/// <summary>
	/// A base class representing an HTTP entity body and content headers.
	/// </summary>
	public abstract class HttpContent : IDisposable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="HttpContent" /> class.
		/// </summary>
		protected HttpContent()
		{
			this.Headers = new HttpContentHeaders(new WebHeaderCollection());
		}

		/// <summary>
		/// Gets the HTTP content headers as defined in RFC 2616.
		/// </summary>
		/// <value>
		/// Returns System.Net.Http.Headers.HttpContentHeaders.The content headers as
		/// defined in RFC 2616.
		/// </value>
		public HttpContentHeaders Headers { get; internal set; }

		/// <summary>
		/// Write the HTTP content to a stream as an asynchronous operation.
		/// </summary>
		/// <param name="stream">The target stream.</param>
		/// <returns>
		/// The task object representing the asynchronous operation.
		/// </returns>
		public Task CopyToAsync(Stream stream)
		{
			return CopyToAsync(stream, null);
		}

		/// <summary>
		/// Write the HTTP content to a stream as an asynchronous operation.
		/// </summary>
		/// <param name="stream">The target stream.</param>
		/// <param name="context">
		/// Information about the transport (channel binding token, for example). This
		/// parameter may be null.
		/// </param>
		/// <returns>
		/// The task object representing the asynchronous operation.
		/// </returns>
		public Task CopyToAsync(Stream stream, TransportContext context)
		{
			return SerializeToStreamAsync(stream, context);
		}

		/// <summary>
		/// Write the HTTP content to a memory stream as an asynchronous operation.
		/// </summary>
		/// <returns>
		/// The task object representing the asynchronous operation.
		/// </returns>
		protected virtual Task<Stream> CreateContentReadStreamAsync()
		{
			//TODO
			throw new NotImplementedException();
		}

		/// <summary>
		/// Serialize the HTTP content to a memory buffer as an asynchronous operation.
		/// </summary>
		/// <returns>
		///  The task object representing the asynchronous operation.
		/// </returns>
		public Task LoadIntoBufferAsync()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Serialize the HTTP content to a memory buffer as an asynchronous operation.
		/// </summary>
		/// <param name="maxBufferSize">The maximum size, in bytes, of the buffer to use.</param>
		/// <returns>
		/// The task object representing the asynchronous operation.
		/// </returns>
		public Task LoadIntoBufferAsync(long maxBufferSize)
		{
			throw new NotImplementedException();
		}

		public Task<System.IO.Stream> ReadAsStreamAsync()
		{
			return CreateContentReadStreamAsync();
		}

		public async Task<byte[]> ReadAsByteArrayAsync()
		{
			Stream stream = await ReadAsStreamAsync();
			if (!stream.CanSeek)
			{
				MemoryStream ms = new MemoryStream();
				int count = 0;
				byte[] buffer = new byte[1024];
				while ((count = await stream.ReadAsync(buffer, 0, 1024)) > 0)
				{
					ms.Write(buffer, 0, count);
				}
				return ms.ToArray();
			}
			else
			{
				byte[] buffer = new byte[stream.Length];
				await stream.ReadAsync(buffer, 0, buffer.Length);
				return buffer;
			}
		}

		public async Task<string> ReadAsStringAsync()
		{
			var bytes = await ReadAsByteArrayAsync();
			return UTF8Encoding.UTF8.GetString(bytes, 0, bytes.Length);
		}

		/// <summary>
		/// Serialize the HTTP content to a stream as an asynchronous operation.
		/// </summary>
		/// <param name="stream">The target stream.</param>
		/// <param name="context">
		/// Information about the transport (channel binding token, for example). This
		/// parameter may be null.
		/// </param>
		/// <returns>
		/// The task object representing the asynchronous operation.
		/// </returns>
		protected abstract Task SerializeToStreamAsync(Stream stream, TransportContext context);
	
		/// <summary>
		/// Determines whether the HTTP content has a valid length in bytes.
		/// </summary>
		/// <param name="length">The length in bytes of the HHTP content.</param>
		/// <returns>true if length is a valid length; otherwise, false.</returns>
		protected internal abstract bool TryComputeLength(out long length);

		/// <summary>
		/// Releases the unmanaged resources and disposes of the managed resources used
		/// by the <see cref="HttpContent"/>.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
		}

		/// <summary>
		/// Releases the unmanaged resources used by the <see cref="HttpContent"/>
		/// and optionally disposes of the managed resources.
		/// </summary>
		/// <param name="disposing">
		/// true to release both managed and unmanaged resources; false to releases only
		/// unmanaged resources.
		/// </param>
		protected virtual void Dispose(bool disposing)
		{

		}
	}
}
