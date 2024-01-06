using ShopProjectExternalModel.Responses;
using ShopProjectExternalModel.User;

namespace ShopProjectAPI.Interfaces
{
    public interface IUserRepository
    {
        bool Login(UserLoginModel userLogin);
        UserRegistrationMessage Register (UserRegisterModel userRegister);
    }
}