using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Net.Http
{
	/// <summary>
	/// Provides HTTP content based on a byte array.
	/// </summary>
	public class ByteArrayContent : HttpContent
	{
		private MemoryStream m_buffer;

		// Summary:
		//     Initializes a new instance of the System.Net.Http.ByteArrayContent class.
		//
		// Parameters:
		//   content:
		//     The content used to initialize the System.Net.Http.ByteArrayContent.
		//
		// Exceptions:
		//   System.ArgumentNullException:
		//     The content parameter is null.
		public ByteArrayContent(byte[] content) : this(content, 0, content.Length)
		{
		}
		//
		// Summary:
		//     Initializes a new instance of the System.Net.Http.ByteArrayContent class.
		//
		// Parameters:
		//   content:
		//     The content used to initialize the System.Net.Http.ByteArrayContent.
		//
		//   offset:
		//     The offset, in bytes, in the content parameter used to initialize the System.Net.Http.ByteArrayContent.
		//
		//   count:
		//     The number of bytes in the content starting from the offset parameter used
		//     to initialize the System.Net.Http.ByteArrayContent.
		//
		// Exceptions:
		//   System.ArgumentNullException:
		//     The content parameter is null.
		//
		//   System.ArgumentOutOfRangeException:
		//     The offset parameter is less than zero.-or-The offset parameter is greater
		//     than the length of content specified by the content parameter.-or-The count
		//      parameter is less than zero.-or-The count parameter is greater than the
		//     length of content specified by the content parameter - minus the offset parameter.
		public ByteArrayContent(byte[] content, int offset, int count)
		{
			if (content == null)
				throw new ArgumentNullException("content");
			if (offset < 0)
				throw new ArgumentOutOfRangeException("offset");
			if (count < 0 || count > content.Length)
				throw new ArgumentOutOfRangeException("offset");
			m_buffer = new MemoryStream(content, offset, count);
		}

		// Summary:
		//     Creates an HTTP content stream as an asynchronous operation for reading whose
		//     backing store is memory from the System.Net.Http.ByteArrayContent.
		//
		// Returns:
		//     Returns System.Threading.Tasks.Task<TResult>.The task object representing
		//     the asynchronous operation.
		protected override Task<Stream> CreateContentReadStreamAsync()
		{
#if WP7
			return TaskEx.FromResult<Stream>(m_buffer);
#else
			return Task.FromResult<Stream>(m_buffer);
#endif
		}

		/// <summary>
		/// Serialize and write the byte array provided in the constructor to an HTTP 
		/// content to a stream as an asynchronous operation.
		/// </summary>
		/// <param name="stream">The target stream.</param>
		/// <param name="context">Information about the transport (channel binding token, for example). This
		/// parameter may be null.</param>
		/// <returns>
		/// The task object representing the asynchronous operation.
		/// </returns>
		protected override Threading.Tasks.Task SerializeToStreamAsync(IO.Stream stream, TransportContext context)
		{
			return m_buffer.CopyToAsync(stream);
		}

		/// <summary>
		/// Determines whether a byte array has a valid length in bytes.
		/// </summary>
		/// <param name="length">The length in bytes of the byte array.</param>
		/// <returns>
		/// true if length is a valid length; otherwise, false.
		/// </returns>
		protected internal override bool TryComputeLength(out long length)
		{
			length = m_buffer.Length;
			return true;
		}
	}
}
