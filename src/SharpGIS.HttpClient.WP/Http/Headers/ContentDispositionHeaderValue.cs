using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Net.Http.Headers
{
	/// <summary>
	/// Represents the value of the Content-Disposition header.
	/// </summary>
	public class ContentDispositionHeaderValue
	{
		// Summary:
		//     Initializes a new instance of the System.Net.Http.Headers.ContentDispositionHeaderValue
		//     class.
		//
		// Parameters:
		//   source:
		//     A System.Net.Http.Headers.ContentDispositionHeaderValue.
		protected ContentDispositionHeaderValue(ContentDispositionHeaderValue source)
		{
		}
		//
		// Summary:
		//     Initializes a new instance of the System.Net.Http.Headers.ContentDispositionHeaderValue
		//     class.
		//
		// Parameters:
		//   dispositionType:
		//     A string that contains a System.Net.Http.Headers.ContentDispositionHeaderValue.
		public ContentDispositionHeaderValue(string dispositionType)
		{ }
	}
}
