using Romsoft.GESTIONCLINICA.Business.Logic.Interfaces.IFAR_CONSIGNACIONBL;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Tablas;
using Romsoft.GESTIONCLINICA.Entidades.FAR_CONSIGNACION;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romsoft.GESTIONCLINICA.Business.Logic.Tablas
{
    public class FAR_CONSIGNACIONBL : Singleton<FAR_CONSIGNACIONBL>, IFAR_CONSIGNACIONBL<FAR_CONSIGNACION>
    {
        public int Add(FAR_CONSIGNACION entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(FAR_CONSIGNACION entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(FAR_CONSIGNACION entity)
        {
            throw new NotImplementedException();
        }

        public IList<FAR_CONSIGNACION> GetAll(string whereFilters)
        {
            throw new NotImplementedException();
        }

        public IList<FAR_CONSIGNACION> GetAllActives()
        {
            return FAR_CONSIGNACIONRepository.Instancia.GetAllActives();
        }

        public IList<FAR_CONSIGNACION> GetAllFilters(FAR_CONSIGNACION entity)
        {
            throw new NotImplementedException();
        }

        public IList<FAR_CONSIGNACION> GetAllPaging(PaginationParameter paginationParameters)
        {
            throw new NotImplementedException();
        }

        public FAR_CONSIGNACION GetByEstado(string rolNombre)
        {
            throw new NotImplementedException();
        }

        public int Update(FAR_CONSIGNACION entity)
        {
            throw new NotImplementedException();
        }
    }
}
