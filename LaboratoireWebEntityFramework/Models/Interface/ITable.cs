using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoireWebEntityFramework.Models.Interface
{
    public interface ITable
    {
        Int32 Id { get; set; }
        DateTime? DateCreation { get; set; }
        bool Actif { get; set; }
    }
}
