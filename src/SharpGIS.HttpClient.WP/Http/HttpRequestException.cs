using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Net.Http
{
	/// <summary>
	///  A base class for exceptions thrown by the System.Net.Http.HttpClient and
	///  System.Net.Http.HttpMessageHandler classes.
	///  </summary>
	public class HttpRequestException : WebException
	{
		public HttpRequestException() { }
		public HttpRequestException(string message) : base(message) { }
		public HttpRequestException(string message, Exception inner) : base(message, inner) { }
	}
}
