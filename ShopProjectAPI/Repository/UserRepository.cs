using ShopProjectAPI.DB;
using ShopProjectAPI.Interfaces;
using ShopProjectExternalModel.User;

namespace ShopProjectAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        ShopprojectContext db;

        public UserRepository(ShopprojectContext db)
        {
            this.db = db;
        }

        public bool Login(UserLoginModel userLogin)
        {
            if (String.IsNullOrWhiteSpace(userLogin.Username)) throw new Exception("Nie wpisano nazwy użytkownika");
            if (String.IsNullOrWhiteSpace(userLogin.Password)) throw new Exception("Nie wpisano hasła");

            var checkUser = db.Users.FirstOrDefault(x => x.Username == userLogin.Username);
            if (checkUser != null)
            {
                if (checkUser.Password != userLogin.Password)
                {
                    throw new Exception("Błędne hasło.");
                }
                else
                {
                    return true;
                }
            }
            else
            {
                throw new Exception("Nie znaleziono użytkownika o takiej nazwie.");
            }
        }

        public bool Register(UserRegisterModel userRegister)
        {
            if (String.IsNullOrWhiteSpace(userRegister.Username)) throw new Exception("Nazwa użytkownika nie może byc pusta");
            if (String.IsNullOrWhiteSpace(userRegister.Password)) throw new Exception("Hasło nie może być puste");
            if (String.IsNullOrWhiteSpace(userRegister.Email)) throw new Exception("Email nie może być pusty");

            var checkUserRegister = db.Users.Any(x => x.Username == userRegister.Username && x.Email == userRegister.Email);
            if (checkUserRegister) throw new Exception("Użytkownik o podanych parametrach już występuje");
            else
            {
                db.Users.Add(new User 
                { 
                    Username = userRegister.Username,
                    Password = userRegister.Password,
                    Email = userRegister.Email,
                });
                db.SaveChanges();
                return true;
            }
        }
    }
}
