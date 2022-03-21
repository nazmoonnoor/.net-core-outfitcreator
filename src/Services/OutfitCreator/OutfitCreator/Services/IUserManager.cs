using System.Threading.Tasks;

namespace OutfitCreator.Services
{
    /// <summary>
    /// User Manager implementation to talk with Identity
    /// </summary>
    public interface IUserManager
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterModel model);
        Task<UserManagerResponse> LoginUserAsync(LoginModel model);
        Task<UserManagerResponse> SignOutUserAsync();
    }
}
