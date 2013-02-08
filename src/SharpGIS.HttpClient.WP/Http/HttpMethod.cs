using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Net.Http
{
	/// <summary>
	/// A helper class for retrieving and comparing standard HTTP methods.
	/// </summary>
	public class HttpMethod : IEquatable<HttpMethod>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="HttpMethod"/> class with a
		/// specific HTTP method. </summary>
		/// <param name="method">The HTTP method.</param>
		public HttpMethod(string method)
		{
			Method = method;
		}
		// Summary:
		//     The inequality operator for comparing two System.Net.Http.HttpMethod objects.
		//
		// Parameters:
		//   left:
		//     The left System.Net.Http.HttpMethod to an inequality operator.
		//
		//   right:
		//     The right System.Net.Http.HttpMethod to an inequality operator.
		//
		// Returns:
		//     Returns System.Boolean.true if the specified left and right parameters are
		//     inequal; otherwise, false.
		public static bool operator !=(HttpMethod left, HttpMethod right)
		{
			return left.Method != right.Method;
		}
		//
		// Summary:
		//     The equality operator for comparing two System.Net.Http.HttpMethod objects.
		//
		// Parameters:
		//   left:
		//     The left System.Net.Http.HttpMethod to an equality operator.
		//
		//   right:
		//     The right System.Net.Http.HttpMethod to an equality operator.
		//
		// Returns:
		//     Returns System.Boolean.true if the specified left and right parameters are
		//     equal; otherwise, false.
		public static bool operator ==(HttpMethod left, HttpMethod right)
		{
			return left.Method == right.Method;
		}

		/// <summary>
		/// Represents an HTTP DELETE protocol method.
		/// </summary>
		/// <value>
		/// Returns <see cref="HttpMethod"/
		/// </value>
		public static HttpMethod Delete { get { return new HttpMethod("DELETE"); } }

		/// <summary>
		/// Represents an HTTP GET protocol method.
		/// </summary>
		/// <value>
		/// Returns <see cref="HttpMethod"/
		/// </value>
		public static HttpMethod Get { get { return new HttpMethod("GET"); } }

		/// <summary>
		///  Represents an HTTP HEAD protocol method. The HEAD method is identical to
		///  GET except that the server only returns message-headers in the response,
		///  without a message-body.
		/// </summary>
		/// <value>
		/// Returns <see cref="HttpMethod"/
		/// </value>
		public static HttpMethod Head { get { return new HttpMethod("HEAD"); } }
		
		/// <summary>
		/// An HTTP method.
		/// </summary>
		/// <value>
		///  Returns <see cref="System.String"/>. An HTTP method represented as a <see cref="System.String"/>.
		/// </value>
		public string Method { get; private set; }
		//
		// Summary:
		//     Represents an HTTP OPTIONS protocol method.
		//
		// Returns:
		//     Returns System.Net.Http.HttpMethod.
		public static HttpMethod Options { get { return new HttpMethod("OPTIONS"); } }
		
		/// <summary>
		///  Represents an HTTP POST protocol method that is used to post a new entity
		///  as an addition to a URI.
		/// </summary>
		/// <value>
		/// Returns <see cref="HttpMethod"/
		/// </value>
		public static HttpMethod Post { get { return new HttpMethod("POST"); } }

		/// <summary>
		///  Represents an HTTP PUT protocol method that is used to post a new entity
		///  as an addition to a URI.
		/// </summary>
		/// <value>
		/// Returns <see cref="HttpMethod"/
		/// </value>
		public static HttpMethod Put { get { return new HttpMethod("PUT"); } }

		/// <summary>
		/// Represents an HTTP TRACE protocol method.
		/// </summary>
		/// <value>
		/// Returns <see cref="HttpMethod"/
		/// </value>
		public static HttpMethod Trace { get { return new HttpMethod("TRACE"); } }

		// Summary:
		//     Determines whether the specified System.Net.Http.HttpMethod is equal to the
		//     current System.Object.
		//
		// Parameters:
		//   other:
		//     The HTTP method to compare with the current object.
		//
		// Returns:
		//     Returns System.Boolean.true if the specified object is equal to the current
		//     object; otherwise, false.
		public bool Equals(HttpMethod other)
		{
			return Method.Equals(other.Method);
		}
		//
		// Summary:
		//     Determines whether the specified System.Object is equal to the current System.Object.
		//
		// Parameters:
		//   obj:
		//     The object to compare with the current object.
		//
		// Returns:
		//     Returns System.Boolean.true if the specified object is equal to the current
		//     object; otherwise, false.
		public override bool Equals(object obj){
			return Method.Equals((obj as HttpMethod).Method);
		}

		/// <summary>
		/// Serves as a hash function for this type.
		/// </summary>
		/// <returns>
		/// Returns <see cref="System.Int32"/>. A hash code for the current System.Object.
		/// </returns>
		public override int GetHashCode() { return Method.GetHashCode(); }
		
		/// <summary>
		/// Returns a <see cref="System.String" /> that represents the current object.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents the current object.
		/// </returns>
		public override string ToString()
		{ return Method; }

	}
}
