using ChallengeHAPSA.Domain.Common;
using ChallengeHAPSA.Domain.Common.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeHAPSA.Api.Helpers
{
    public static class ResultExtensions
    {
        public static ActionResult ToActionResult(this ControllerBase controller, Result result)
        {
            if (result.IsSuccess)
            {
                return controller.Ok(result);
            }

            return controller.StatusCode(StatusCodeFor(result.Error!.Code), Result.Failure(result.Error!));
        }

        private static int StatusCodeFor(ErrorCodes code) => code switch
        {
            ErrorCodes.HORSE_NOT_FOUND => StatusCodes.Status404NotFound,
            ErrorCodes.HORSE_NAME_IN_USE => StatusCodes.Status409Conflict,
            ErrorCodes.HORSE_ALREADY_DISABLED => StatusCodes.Status409Conflict,
            ErrorCodes.HORSE_ALREADY_ENABLED => StatusCodes.Status409Conflict,
            ErrorCodes.HORSE_NAME_NOT_ALLOWED => StatusCodes.Status400BadRequest,
            ErrorCodes.UNKNOWN_ERROR => StatusCodes.Status500InternalServerError,
            _ => StatusCodes.Status400BadRequest
        };
    }
}
