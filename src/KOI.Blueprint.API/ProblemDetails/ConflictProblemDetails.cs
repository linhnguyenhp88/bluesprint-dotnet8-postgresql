using KOI.Blueprint.Application.Exceptions;
using Microsoft.AspNetCore.Http;

namespace KOI.Blueprint.API.ProblemDetails
{
    public class ConflictProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public ConflictProblemDetails(ConflictException ex)
        {
            Status = StatusCodes.Status409Conflict;
            Title = "Conflict";
            Detail = ex?.Message;
            Type = "https://httpstatuses.com/409";
        }
    }
}
