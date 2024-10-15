using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace WebApi;

public static class ResultExtensions
{
    public static IActionResult MapResult(this Result result)
    {
        if (result.IsSucess)
        {
            return new OkResult();
        }

        return GetErrorResult(result.Error);
    }

    public static IActionResult MapResult<T>(this Result<T> result)
    {
        if (result.IsSucess)
        {
            return new OkObjectResult(result.Value);
        }

        return GetErrorResult(result.Error);
    }

    public static IActionResult MapCreatedResult<T>(this Result<T> result)
    {
        if (result.IsSucess)
        {
            return new ObjectResult(result.Value)
            {
                StatusCode = (int)HttpStatusCode.Created
            };
        }

        return GetErrorResult(result.Error);
    }

    private static IActionResult GetErrorResult(Error error)
    {
        return error.GetType() switch
        {
            TypeError.Validation => new BadRequestObjectResult(error),
            TypeError.NotFound => new NotFoundObjectResult(error),
            _ => throw new Exception("TypeErro invalid")
        };
    }
}
