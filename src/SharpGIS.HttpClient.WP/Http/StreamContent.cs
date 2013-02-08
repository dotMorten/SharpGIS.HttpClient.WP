using System.IO;
using System.Threading.Tasks;

namespace System.Net.Http
{
	/// <summary>
	/// Provides HTTP content based on a stream.
	/// </summary>
	public class StreamContent : HttpContent
	{
		private System.IO.Stream m_stream;

		/// <summary>
		/// Creates a new instance of the <see cref="StreamContent" /> class.
		/// </summary>
		/// <param name="content">The content used to initialize the System.Net.Http.StreamContent.</param>
		/// <exception cref="System.ArgumentNullException">content</exception>
		public StreamContent(Stream content)
		{
			if (content == null)
				throw new ArgumentNullException("content");
			m_stream = content;
		}
		/// <summary>
		/// Creates a new instance of the <see cref="StreamContent" /> class.
		/// </summary>
		/// <param name="content">The content used to initialize the <see cref="StreamContent"/></param>
		/// <param name="bufferSize">The size, in bytes, of the buffer for the <see cref="StreamContent"/>.</param>
		public StreamContent(Stream content, int bufferSize)
			: this(content)
		{
			if (bufferSize <= 0)
				throw new ArgumentOutOfRangeException("bufferSize", "The bufferSize was is than or equal to zero.");
		}

		/// <summary>
		///  Write the HTTP content to a memory stream as an asynchronous operation.
		/// </summary>
		/// <returns>
		/// Returns System.Threading.Tasks.Task&lt;TResult&gt;.The task object representing
		/// the asynchronous operation.
		/// </returns>
		protected override Task<Stream> CreateContentReadStreamAsync()
		{
#if WP7
			return TaskEx.FromResult(m_stream);
#else
			return Task.FromResult(m_stream);
#endif
		}

		/// <summary>
		/// Serialize the HTTP content to a stream as an asynchronous operation.
		/// </summary>
		/// <param name="stream">The target stream.</param>
		/// <param name="context">Information about the transport (channel binding token, for example). This
		/// parameter may be null.</param>
		/// <returns>
		/// Returns System.Threading.Tasks.Task.The task object representing the asynchronous
		/// operation.
		/// </returns>
		protected override Task SerializeToStreamAsync(Stream stream, System.Net.TransportContext context)
		{
			return m_stream.CopyToAsync(stream);
		}

		/// <summary>
		/// Determines whether the HTTP content has a valid length in bytes.
		/// </summary>
		/// <param name="length">The length in bytes of the HHTP content.</param>
		/// <returns>Returns System.Boolean.true if length is a valid length; otherwise, false.</returns>
		protected internal override bool TryComputeLength(out long length)
		{
			if (m_stream.CanSeek)
			{
				length = m_stream.Length;
				return true;
			}
			else
			{
				length = -1;
				return false;
			}
		}
	}
}
