using ShopProjectInfrastructure.DB;
using ShopProjectInfrastructure.Interfaces;
using ShopProjectExternalModel.Responses;
using ShopProjectExternalModel.User;

namespace ShopProjectInfrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        ShopprojectContext db;

        public UserRepository(ShopprojectContext db)
        {
            this.db = db;
        }

        public UserLoginMessage Login(UserLoginModel userLogin)
        {
            if (String.IsNullOrWhiteSpace(userLogin.Username)) return null;
            if (String.IsNullOrWhiteSpace(userLogin.Password)) return null;

            var checkUser = db.Users.FirstOrDefault(x => x.Username == userLogin.Username);
            if (checkUser != null)
            {
                if (checkUser.Password != userLogin.Password)
                {
                    return null;
                }
                else
                {
                    return new UserLoginMessage
                    {
                        Username = checkUser.Username,
                        UserId = checkUser.Id
                    };
                }
            }
            else
            {
                return null;
            }
        }

        public UserRegistrationMessage Register(UserRegisterModel userRegister)
        {
            if (String.IsNullOrWhiteSpace(userRegister.Username)) throw new Exception("Nazwa użytkownika nie może byc pusta");
            if (String.IsNullOrWhiteSpace(userRegister.Password)) throw new Exception("Hasło nie może być puste");
            if (String.IsNullOrWhiteSpace(userRegister.Email)) throw new Exception("Email nie może być pusty");

            var resultMessage = new UserRegistrationMessage();
            resultMessage.Errors = new Dictionary<string, string>();

            var checkUsernameRegister = db.Users.Any(x => x.Username == userRegister.Username);
            if (checkUsernameRegister)
            {
                resultMessage.isSuccess = false;
                resultMessage.Errors.Add("Username", "Użytkownik o podanej nazwie już istnieje");
            }

            var checkUserEmailRegister = db.Users.Any(x => x.Email == userRegister.Email);
            if (checkUserEmailRegister)
            {
                resultMessage.isSuccess = false;
                resultMessage.Errors.Add("Email", "Użytkownik o podanym mailu już istnieje");
            }

            if (!checkUsernameRegister && !checkUserEmailRegister)
            {
                db.Users.Add(new User 
                { 
                    Username = userRegister.Username,
                    Password = userRegister.Password,
                    Email = userRegister.Email,
                });
                db.SaveChanges();

                resultMessage.isSuccess = true;
                resultMessage.Errors = null;
                return resultMessage;
            }
            else
            {
                return resultMessage;
            }
        }

        public UserLoginDataMessage GetUserById(int UserId)
        {
            var result = db.Users.Select(x => new UserLoginDataMessage
            {
                Id = x.Id,
                Username = x.Username,
                Email = x.Email
            }).FirstOrDefault(x => x.Id == UserId);

            if (result != null) return result;
            else return null;
        }

        public bool ChangePassword(int UserId, string pass)
        {
            var result = db.Users.FirstOrDefault(x => x.Id == UserId);
            if (result != null)
            {
                result.Password = pass;
                db.SaveChanges();
                return true;
            }
            else return false;
        }

        public bool DeleteUser(int UserId)
        {
            var result = db.Users.FirstOrDefault(x => x.Id == UserId);
            if (result != null)
            {
                db.Users.Remove(result);
                db.SaveChanges();
                return true;
            } else return false;
        }

        public bool CheckUserById(int UserId)
        {
            if (db.Users.FirstOrDefault(x => x.Id == UserId) == null) return false;
            else return true;
        }
    }
}
