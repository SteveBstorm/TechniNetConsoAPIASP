using DemoASPMVC_DAL.Models;

namespace DemoASPMVC_DAL.Interface
{
    public interface IUserService 
    {
        string Login(string email, string pwd);
        bool Register(string email, string pwd, string nickname);
        User GetById(int id);
        IEnumerable<User> GetUsers(string token);

        bool SetRole(int idUser, int idRole, string token);
    }
}