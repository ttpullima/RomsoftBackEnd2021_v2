using Microsoft.Practices.EnterpriseLibrary.Data;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.Common.Generics;
using Romsoft.GESTIONCLINICA.DataAccess.Core;
using Romsoft.GESTIONCLINICA.DataAccess.Interfaces.IFAR_CONSIGNACIONRepository;
using Romsoft.GESTIONCLINICA.Entidades.FAR_CONSIGNACION;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Romsoft.GESTIONCLINICA.DataAccess.Tablas
{
    public class FAR_CONSIGNACIONRepository : Singleton<FAR_CONSIGNACIONRepository>, IFAR_CONSIGNACIONRepository<FAR_CONSIGNACION>
    {
        #region Attributos
        private readonly Database _database = new DatabaseProviderFactory().Create(ConectionStringRepository.ConnectionStringNameSQL);
        #endregion

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
            List<FAR_CONSIGNACION> listConsignacion= new List<FAR_CONSIGNACION>();
            using (var comando = _database.GetStoredProcCommand(string.Format("{0}{1}", ConectionStringRepository.EsquemaName, "p_FAR_CONSIGNACION_GetAllActives")))
            {

                using (var lector = _database.ExecuteReader(comando))
                {
                    while (lector.Read())
                    {
                        listConsignacion.Add(new FAR_CONSIGNACION
                        {
                            id_consignacion = lector.IsDBNull(lector.GetOrdinal("id_consignacion")) ? default(int) : lector.GetInt32(lector.GetOrdinal("id_consignacion")),
                            c_codigo = lector.IsDBNull(lector.GetOrdinal("c_codigo")) ? default(string) : lector.GetString(lector.GetOrdinal("c_codigo")),
                            t_descripcion = lector.IsDBNull(lector.GetOrdinal("t_descripcion")) ? default(string) : lector.GetString(lector.GetOrdinal("t_descripcion")),

                        });
                    }
                }
            }

            return listConsignacion;
        }

        public IList<FAR_CONSIGNACION> GetAllFilters(FAR_CONSIGNACION entity)
        {
            throw new NotImplementedException();
        }

        public IList<FAR_CONSIGNACION> GetAllPaging(PaginationParameter paginationParameters)
        {
            throw new NotImplementedException();
        }

        public int Update(FAR_CONSIGNACION entity)
        {
            throw new NotImplementedException();
        }
    }
}
