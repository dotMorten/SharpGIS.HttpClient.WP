
namespace System.Net.Http
{
	/// <summary>
	/// Indicates if System.Net.Http.HttpClient operations should be considered completed
	/// either as soon as a response is available, or after reading the entire response
	/// message including the content.
	/// </summary>
	public enum HttpCompletionOption
	{
		/// <summary>
		/// The operation should complete after reading the entire response including
		/// the content.
		/// </summary>
		ResponseContentRead = 0,
		
   		/// <summary>
		/// The operation should complete as soon as a response is available and headers
		/// are read. The content is not read yet.
   		/// </summary>
		ResponseHeadersRead = 1,
	}
}
