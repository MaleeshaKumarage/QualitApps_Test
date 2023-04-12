


using Microsoft.AspNetCore.Mvc;
using QualitApps_Test.Models.Enums;

namespace QualitApps_Test.API
{
    public class ResultJsonGenerator
    {
        public static JsonResult Generate(RequestStatus status, string message, int? statusCode)
        {
            return new JsonResult(new
            {
                status = status,
                message = $"{message}"
            })
            {
                StatusCode = statusCode
            };

        }
    }
}
