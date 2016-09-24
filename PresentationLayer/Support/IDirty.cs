using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Support
{
    interface IDirty<in T>
    {
        bool Dirty(T cache);
    }
}
