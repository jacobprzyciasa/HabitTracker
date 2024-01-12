using Blazored.LocalStorage;
using HabitTracker.Shared.DataTransferObjects;

namespace HabitTracker.Web.Services
{
    public class TokenService : ITokenService
    {
        private readonly ILocalStorageService localStorageService;

        public TokenService(ILocalStorageService localStorageService)
        {
            this.localStorageService = localStorageService;
        }

        public async Task SetToken(TokenDto tokenDTO)
        {
            await localStorageService.SetItemAsync("token", tokenDTO);
        }

        public async Task<TokenDto> GetToken()
        {
            return await localStorageService.GetItemAsync<TokenDto>("token");
        }

        public async Task RemoveToken()
        {
            await localStorageService.RemoveItemAsync("token");
        }
    }
}
