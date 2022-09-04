using System.Net;

namespace Services.Exceptions;

public class ApiException : Exception
{
	public HttpStatusCode StatusCode;

	public ApiException(HttpStatusCode statusCode) : base()
	{
		StatusCode = statusCode;
	}

	public ApiException(HttpStatusCode statusCode, string message) : base(message)
	{
		StatusCode = statusCode;
	}
}
