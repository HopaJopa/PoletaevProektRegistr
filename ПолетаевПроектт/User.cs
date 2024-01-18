using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПолетаевПроектт
{
    public class User
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string login { get; set; }
        public string password { get; set; }
    }
}
