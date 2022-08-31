using System.Net;

namespace Exceptions;

public class ApiException : Exception
{
	public ApiException(HttpStatusCode statusCode) : base() { }

	public ApiException(HttpStatusCode statusCode, string message) : base(message) { }
}
