using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Models.ContentLayerDummy
{
    public interface IContentProvider<T>
    {
        ICollection<T> Query();
        ICollection<T> QueryById(int id);
        int Insert(T itemToInsert);

        int Update(T item);

        int Delete(T itemToDelete);
    }
}
