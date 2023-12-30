using Microsoft.AspNetCore.Identity;

namespace HabitTracker.Shared
{
    public class User : IdentityUser<int>
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

    }
}