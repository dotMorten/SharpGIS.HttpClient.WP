SharpGIS.HttpClient.WP
----------------------------------------------------------------------------


UPDATE: THIS PROJECT HAS BEEN DISCONTINUED. PLEASE USE THE OFFICIAL MICROSOFT PROVIDED HTTP CLIENT LIBRARY: https://www.nuget.org/packages/Microsoft.Net.Http

======================


HttpClient implementation for Windows Phone.
Allows you to share HttpClient code between Windows 8 and Windows Phone 8.


Note: This is still very much a work in progress. Many properties are still not implemented, 
but most basic GET and POST operations work.


The client also supports 'gzip' compression (but not 'deflate').
As with Windows 8, you have to opt in for compression by specifying it on the HttpHandler parameter.

Example:


System.Net.Http.HttpClient client = new System.Net.Http.HttpClient(
        new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip }
);
