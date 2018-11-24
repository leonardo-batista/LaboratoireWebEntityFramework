using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebEntityFramework.Tests.Class;

namespace WebEntityFramework.Tests.Interface
{
    public interface IContext
    {
        IDbSet<Produit> Produits { get; set; }
    }
}
