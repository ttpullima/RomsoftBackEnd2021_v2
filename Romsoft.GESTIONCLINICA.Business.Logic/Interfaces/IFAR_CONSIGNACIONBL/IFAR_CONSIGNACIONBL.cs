using Romsoft.GESTIONCLINICA.Business.Logic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romsoft.GESTIONCLINICA.Business.Logic.Interfaces.IFAR_CONSIGNACIONBL
{
    public interface IFAR_CONSIGNACIONBL<T> : ILogic<T> where T : class
    {
        bool Exists(T entity);
        T GetByEstado(string rolNombre);

        IList<T> GetAllActives();
    }
}
