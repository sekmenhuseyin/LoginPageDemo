using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPageDemo.WebService.Models
{
    /// <summary>
    /// giriş sonrası gelen veri
    /// </summary>
    public interface Login
    {
        int ID { get; set; }
        string Guid { get; set; }
        string Kod { get; set; }
        string AdSoyad { get; set; }
        string DepoKodu { get; set; }
        int DepoID { get; set; }
    }
}
