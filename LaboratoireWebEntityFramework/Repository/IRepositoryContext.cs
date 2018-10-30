using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoireWebEntityFramework.Repository
{
    public interface IRepositoryContext<T> where T : class
    {
        IEnumerable<T> List();

        T GetModelById(int id);

        T GetModelByName(string name);

        void InsertModel(T model);

        void UpdateModel(T model);

        void DeleteModel(T model);

        void DeleteModelById(int id);

        void Save();

    }
}
