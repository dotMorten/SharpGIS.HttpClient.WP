using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Net.Http.Headers
{
	/// <summary>
	/// Represents the collection of Content Headers as defined in RFC 2616.
	/// </summary>
	public sealed class HttpContentHeaders : HttpHeaders
	{
		internal HttpContentHeaders(WebHeaderCollection headers)
			: base(headers)
		{

		}
		// Summary:
		//     Gets the value of the Allow content header on an HTTP response.
		//
		// Returns:
		//     Returns System.Collections.Generic.ICollection<T>.The value of the Allow
		//     header on an HTTP response.
		public ICollection<string> Allow { get; private set; }
		//
		// Summary:
		//     Gets the value of the Content-Disposition content header on an HTTP response.
		//
		// Returns:
		//     Returns System.Net.Http.Headers.ContentDispositionHeaderValue.The value of
		//     the Content-Disposition content header on an HTTP response.
		public ContentDispositionHeaderValue ContentDisposition { get; set; }
		//
		// Summary:
		//     Gets the value of the Content-Encoding content header on an HTTP response.
		//
		// Returns:
		//     Returns System.Collections.Generic.ICollection<T>.The value of the Content-Encoding
		//     content header on an HTTP response.
		public ICollection<string> ContentEncoding { get; private set; }
		//
		// Summary:
		//     Gets the value of the Content-Language content header on an HTTP response.
		//
		// Returns:
		//     Returns System.Collections.Generic.ICollection<T>.The value of the Content-Language
		//     content header on an HTTP response.
		public ICollection<string> ContentLanguage { get; private set; }
		//
		// Summary:
		//     Gets or sets the value of the Content-Length content header on an HTTP response.
		//
		// Returns:
		//     Returns System.Int64.The value of the Content-Length content header on an
		//     HTTP response.
		public long? ContentLength { get; set; }
		//
		// Summary:
		//     Gets or sets the value of the Content-Location content header on an HTTP
		//     response.
		//
		// Returns:
		//     Returns System.Uri.The value of the Content-Location content header on an
		//     HTTP response.
		public Uri ContentLocation { get; set; }
		//
		// Summary:
		//     Gets or sets the value of the Content-MD5 content header on an HTTP response.
		//
		// Returns:
		//     Returns System.Byte.The value of the Content-MD5 content header on an HTTP
		//     response.
		public byte[] ContentMD5 { get; set; }
		//
		// Summary:
		//     Gets or sets the value of the Content-Range content header on an HTTP response.
		//
		// Returns:
		//     Returns System.Net.Http.Headers.ContentRangeHeaderValue.The value of the
		//     Content-Range content header on an HTTP response.
		public ContentRangeHeaderValue ContentRange { get; set; }
		//
		// Summary:
		//     Gets or sets the value of the Content-Type content header on an HTTP response.
		//
		// Returns:
		//     Returns System.Net.Http.Headers.MediaTypeHeaderValue.The value of the Content-Type
		//     content header on an HTTP response.
		public MediaTypeHeaderValue ContentType { get; set; }
		//
		// Summary:
		//     Gets or sets the value of the Expires content header on an HTTP response.
		//
		// Returns:
		//     Returns System.DateTimeOffset.The value of the Expires content header on
		//     an HTTP response.
		public DateTimeOffset? Expires { get; set; }
		//
		// Summary:
		//     Gets or sets the value of the Last-Modified content header on an HTTP response.
		//
		// Returns:
		//     Returns System.DateTimeOffset.The value of the Last-Modified content header
		//     on an HTTP response.
		public DateTimeOffset? LastModified { get; set; }
	}
}
