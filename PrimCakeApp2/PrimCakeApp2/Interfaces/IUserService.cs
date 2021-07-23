using System.Threading.Tasks;

namespace PrimCakeApp2.Interfaces
{
    public interface IUserService
    {
        Task<bool> Register(string name, string email, string password);
        Task<bool> Login(string email, string password);
    }
}