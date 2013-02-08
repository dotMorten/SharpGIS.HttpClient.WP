using System;
using System.Net;

namespace SharpGIS.HttpClient.WP.GZip
{
	internal sealed class GZipWebResponse : HttpWebResponse
	{
		private readonly HttpWebResponse _response;
		private readonly GZipInflateStream _stream;

		internal GZipWebResponse(HttpWebResponse resp)
		{
			_response = resp;
			_stream = new GZipInflateStream(_response.GetResponseStream());
		}
		public override System.IO.Stream GetResponseStream()
		{
			return _stream;
		}
		public override void Close()
		{
			_response.Close();
			_stream.Close();
		}
		public override long ContentLength
		{
			get
			{
				return _stream.Length;
			}
		}
		public override string ContentType
		{
			get { return _response.ContentType; }
		}
		public override WebHeaderCollection Headers
		{
			get { return _response.Headers; }
		}
		public override Uri ResponseUri
		{
			get { return _response.ResponseUri; }
		}
		public override bool SupportsHeaders
		{
			get { return _response.SupportsHeaders; }
		}
		public override string Method
		{
			get
			{
				return _response.Method;
			}
		}
		public override HttpStatusCode StatusCode
		{
			get
			{
				return _response.StatusCode;
			}
		}
		public override string StatusDescription
		{
			get
			{
				return _response.StatusDescription;
			}
		}
		public override CookieCollection Cookies
		{
			get
			{
				return _response.Cookies;
			}
		}
	}
}