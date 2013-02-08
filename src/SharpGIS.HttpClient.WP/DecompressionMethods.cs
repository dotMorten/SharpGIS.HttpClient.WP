using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Net
{
	/// <summary>
	/// Represents the file compression and decompression encoding format to be used
	/// to compress the data received in response to an System.Net.HttpWebRequest.
	/// </summary>
	[Flags]
	public enum DecompressionMethods
	{
		/// <summary>
		/// Do not use compression.
		/// </summary>
		None = 0,
		/// <summary>
		/// Use the gZip compression-decompression algorithm.
		/// </summary>
		GZip = 1,

		/* NOT SUPPORTED BY WINPHONE:
		 * /// <summary>
		/// Use the deflate compression-decompression algorithm.
		/// </summary>
		Deflate = 2,
		 * */ 
	}
}
