using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Net.Http
{
	/// <summary>
	/// Provides a container for content encoded using multipart/form-data MIME type.
	/// </summary>
	public class MultipartFormDataContent : MultipartContent
	{
		// Summary:
		//     Creates a new instance of the System.Net.Http.MultipartFormDataContent class.
		public MultipartFormDataContent() : base() 
		{
		}
		//
		// Summary:
		//     Creates a new instance of the System.Net.Http.MultipartFormDataContent class.
		//
		// Parameters:
		//   boundary:
		//     The boundary string for the multipart form data content.
		//
		// Exceptions:
		//   System.ArgumentException:
		//     The boundary was null or contains only white space characters.-or-The boundary
		//     ends with a space character.
		//
		//   System.OutOfRangeException:
		//     The length of the boundary was greater than 70.
		public MultipartFormDataContent(string boundary) : base(boundary)
		{
		}

		// Summary:
		//     Add HTTP content to a collection of System.Net.Http.HttpContent objects that
		//     get serialized to multipart/form-data MIME type.
		//
		// Parameters:
		//   content:
		//     The HTTP content to add to the collection.
		//
		// Exceptions:
		//   System.ArgumentNullException:
		//     The content was null.
		public override void Add(HttpContent content)
		{
			base.Add(content);
		}

		// Summary:
		//     Add HTTP content to a collection of System.Net.Http.HttpContent objects that
		//     get serialized to multipart/form-data MIME type.
		//
		// Parameters:
		//   content:
		//     The HTTP content to add to the collection.
		//
		//   name:
		//     The name for the HTTP content to add.
		//
		// Exceptions:
		//   System.ArgumentException:
		//     The name was null or contains only white space characters.
		//
		//   System.ArgumentNullException:
		//     The content was null.
		public void Add(HttpContent content, string name)
		{
			throw new NotImplementedException(); //TODO
		}

		// Summary:
		//     Add HTTP content to a collection of System.Net.Http.HttpContent objects that
		//     get serialized to multipart/form-data MIME type.
		//
		// Parameters:
		//   content:
		//     The HTTP content to add to the collection.
		//
		//   name:
		//     The name for the HTTP content to add.
		//
		//   fileName:
		//     The file name for the HTTP content to add to the collection.
		//
		// Exceptions:
		//   System.ArgumentException:
		//     The name was null or contains only white space characters.-or-The fileName
		//     was null or contains only white space characters.
		//
		//   System.ArgumentNullException:
		//     The content was null.
		public void Add(HttpContent content, string name, string fileName)
		{
			throw new NotImplementedException(); //TODO
		}
	}
}
