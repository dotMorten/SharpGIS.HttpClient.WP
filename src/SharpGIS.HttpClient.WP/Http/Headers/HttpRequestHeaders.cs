using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Net.Http.Headers
{
	/// <summary>
	/// Represents the collection of Request Headers as defined in RFC 2616.
	/// </summary>
	public sealed class HttpRequestHeaders : HttpHeaders
	{
		internal HttpRequestHeaders(WebHeaderCollection headers)
			: base(headers)
		{
		}
	}
}
