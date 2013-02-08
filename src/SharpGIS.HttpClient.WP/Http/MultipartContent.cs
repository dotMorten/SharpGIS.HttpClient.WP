using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Net.Http
{
	/// <summary>
	/// Provides a collection of System.Net.Http.HttpContent objects that get serialized
	//  using the multipart/* content type specification.
	/// </summary>
	public class MultipartContent : HttpContent, IEnumerable<HttpContent>, IEnumerable
	{
		private List<HttpContent> m_parts = new List<HttpContent>();
		private string m_boundary;
		private string m_subtype;
		/// <summary>
		/// Creates a new instance of the <see cref="MultipartContent" /> class.
		/// </summary>
		public MultipartContent() : this("multipart/form-data") { }

		/// <summary>
		/// Creates a new instance of the <see cref="MultipartContent" /> class.
		/// </summary>
		/// <param name="subtype">The subtype of the multipart content.</param>
		/// <exception cref="System.ArgumentNullException">
		/// The subtype was null or contains only white space characters.
		/// </exception>
		/// <exception cref="System.ArgumentOutOfRangeException">
		/// The length of the boundary was greater than 70.</exception>
		public MultipartContent(string subtype) : 
			this(subtype, string.Format("---------------------------{0}", DateTime.Now.Ticks.ToString().Substring(0, 12)))
		{ 
		}

		/// <summary>
		/// Creates a new instance of the <see cref="MultipartContent" /> class.
		/// </summary>
		/// <param name="subtype">The subtype of the multipart content.</param>
		/// <param name="boundary">The boundary string for the multipart content.</param>
		/// <exception cref="System.ArgumentNullException">
		/// The subtype was null or an empty string. The boundary was null or contains
		/// only white space characters.-or-The boundary ends with a space character.
		/// </exception>
		/// <exception cref="System.ArgumentOutOfRangeException">
		/// The length of the boundary was greater than 70.</exception>
		public MultipartContent(string subtype, string boundary)
		{
			if (string.IsNullOrWhiteSpace(subtype) || subtype.EndsWith(" "))
				throw new ArgumentNullException("subtype");
			if (boundary == null)
				throw new ArgumentNullException("boundary");
			if (boundary.Length > 0)
				throw new ArgumentOutOfRangeException("boundary");
			m_subtype = subtype;
			m_boundary = boundary;
			Headers.Add("Content-Type", new string[] { "multipart/form-data", "boundary=" + boundary });
		}

		/// <summary>
		///  Add multipart HTTP content to a collection of System.Net.Http.HttpContent
		///  objects that get serialized using the multipart/* content type specification.
		/// </summary>
		/// <param name="content">The HTTP content to add to the collection.</param>
		/// <exception cref="System.ArgumentNullException">The content was null.</exception>
		public virtual void Add(HttpContent content)
		{
			if (content == null)
				throw new ArgumentNullException("content");
			m_parts.Add(content);
		}

		/// <summary>
		/// Releases the unmanaged resources used by the <see cref="MultipartContent"/>
		/// and optionally disposes of the managed resources.
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources;
		/// <c>false</c> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{ 
		}

		/// <summary>
		/// Returns an enumerator that iterates through the collection of <see cref="HttpContent"/>
		/// objects that get serialized using the multipart/* content type specification.
		/// </summary>
		/// <returns>
		/// Returns System.Collections.Generic.IEnumerator&lt;T&gt;.An object that can be used
		/// to iterate through the collection.
		/// </returns>
		public IEnumerator<HttpContent> GetEnumerator()
		{
			return m_parts.GetEnumerator();
		}
		
		/// <summary>
		/// Serialize the multipart HTTP content to a stream as an asynchronous operation.
		/// </summary>
		/// <param name="stream">The target stream.</param>
		/// <param name="context">
		/// Information about the transport (channel binding token, for example). This
		/// parameter may be null.
		/// </param>
		/// <returns>
		/// Returns System.Threading.Tasks.Task.The task object representing the asynchronous
		/// operation.
		/// </returns>
		protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context)
		{
			StreamWriter writer = new StreamWriter(stream);
			writer.Write("--");
			writer.Write(m_boundary);
			foreach (var part in m_parts)
			{
				writer.WriteLine();
				await part.CopyToAsync(stream);
				writer.WriteLine();
				await writer.FlushAsync();
				writer.Write("--");
				writer.Write(m_boundary);
				writer.Flush();
			}
			writer.Write("--");
			writer.Flush();
		}
		
		/// <summary>
		/// Determines whether the HTTP multipart content has a valid length in bytes.
		/// </summary>
		/// <param name="length">The length in bytes of the HTTP content.</param>
		/// <returns>true if length is a valid length; otherwise, false.</returns>
		protected internal override bool TryComputeLength(out long length)
		{
			length = -1;
			return false;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
