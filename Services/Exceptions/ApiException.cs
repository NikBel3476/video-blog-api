using System.Net;

namespace Services.Exceptions
{
	public class ApiException : Exception
	{
		public readonly HttpStatusCode StatusCode;

		public ApiException(HttpStatusCode statusCode)
		{
			StatusCode = statusCode;
		}

		public ApiException(HttpStatusCode statusCode, string message) : base(message)
		{
			StatusCode = statusCode;
		}
	}
}
