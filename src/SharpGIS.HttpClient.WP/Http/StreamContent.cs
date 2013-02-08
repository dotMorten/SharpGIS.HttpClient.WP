using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
			return Task.FromResult(m_stream);
		}
	}
}
