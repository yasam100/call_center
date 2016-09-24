using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Models
{
    public class Employee : Contact
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
