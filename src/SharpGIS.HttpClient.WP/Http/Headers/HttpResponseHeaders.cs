using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Net.Http.Headers
{
	/// <summary>
	/// Represents the collection of Response Headers as defined in RFC 2616.
	/// </summary>
	public class HttpResponseHeaders : HttpHeaders
	{
		internal HttpResponseHeaders(WebHeaderCollection headers)
			: base(headers)
		{
		}
		//TODO
	}
}
