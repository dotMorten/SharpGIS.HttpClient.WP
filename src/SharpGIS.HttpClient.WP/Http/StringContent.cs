using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Net.Http
{
	/// <summary>
	/// Provides HTTP content based on a string.
	/// </summary>
	public class StringContent : ByteArrayContent
	{
		/// <summary>
		/// Creates a new instance of the <see cref="StringContent" /> class.
		/// </summary>
		/// <param name="content">The content used to initialize the <see cref="StringContent"/>.</param>
		public StringContent(string content)
			: this(content, UTF8Encoding.UTF8)
		{
		}

		/// <summary>
		/// Creates a new instance of the <see cref="StringContent" /> class.
		/// </summary>
		/// <param name="content">The content used to initialize the <see cref="StringContent"/>.</param>
		/// <param name="encoding">The encoding to use for the content.</param>
		public StringContent(string content, Encoding encoding)
			: this(content, encoding, "text/plain")
		{

		}

		/// <summary>
		/// Creates a new instance of the <see cref="StringContent" /> class.
		/// </summary>
		/// <param name="content">The content used to initialize the <see cref="StringContent"/>.</param>
		/// <param name="encoding">The encoding to use for the content.</param>
		/// <param name="mediaType">The media type to use for the content.</param>
		public StringContent(string content, Encoding encoding, string mediaType) : base(encoding.GetBytes(content))
		{
			Headers.Add("Content-Type", new string[] { mediaType, "charset=" + encoding.WebName });
		}
	}
}
