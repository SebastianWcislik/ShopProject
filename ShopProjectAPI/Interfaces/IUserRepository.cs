using ShopProjectExternalModel.Responses;
using ShopProjectExternalModel.User;

namespace ShopProjectAPI.Interfaces
{
    public interface IUserRepository
    {
        UserLoginMessage Login(UserLoginModel userLogin);
        UserRegistrationMessage Register (UserRegisterModel userRegister);
        bool CheckUserById(int UserId);
    }
}