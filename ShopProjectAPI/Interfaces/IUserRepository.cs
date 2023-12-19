using ShopProjectExternalModel.User;

namespace ShopProjectAPI.Interfaces
{
    public interface IUserRepository
    {
        bool Login(UserLoginModel userLogin);
        bool Register (UserRegisterModel userRegister);
    }
}