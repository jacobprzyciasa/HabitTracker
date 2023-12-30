using Microsoft.IdentityModel.SecurityTokenService;

namespace HabitTracker.Api.Entities.Exeptions
{
    public class RefreshTokenBadRequest : BadRequestException
    {
        public RefreshTokenBadRequest() : base("Invalid client request. The tokenDto has some invalid values.")
        {
        }

    }
}
