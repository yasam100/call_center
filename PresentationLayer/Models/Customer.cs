using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Models
{
    public class Customer : Contact
    {
        public ICollection<ServiceCall> ServiceCalls { get; set; }
    }
}
