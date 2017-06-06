using LoginPageDemo.WebService.Models;
using System.Threading.Tasks;

namespace LoginPageDemo.WebService
{
    public interface IService
    {
        Task<Login> LoginKontrol(string userID, string sifre, string AndroidID);
    }
}
