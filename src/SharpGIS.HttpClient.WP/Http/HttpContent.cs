using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

		}
		/// <summary>
		///  Write the HTTP content to a memory stream as an asynchronous operation.
		/// </summary>
		/// <returns>
		/// Returns System.Threading.Tasks.Task<TResult>.The task object representing
		/// the asynchronous operation.
		/// </returns>
		protected virtual Task<Stream> CreateContentReadStreamAsync()
		{
			//TODO
			throw new NotImplementedException();
		}

		//protected HttpContent(System.IO.Stream stream)
		//{
		//	m_stream = stream;
		//}
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

		public void Dispose()
		{
		}

		/// <summary>
		/// Gets the HTTP content headers as defined in RFC 2616.
		/// </summary>
		/// <value>
		/// Returns System.Net.Http.Headers.HttpContentHeaders.The content headers as
		/// defined in RFC 2616.
		/// </value>
		public HttpContentHeaders Headers { get; internal set; }
	}
}
