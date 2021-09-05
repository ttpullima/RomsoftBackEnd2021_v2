using Romsoft.GESTIONCLINICA.Business.Logic.Tablas;
using Romsoft.GESTIONCLINICA.Common;
using Romsoft.GESTIONCLINICA.DTO.AutoMapper;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.FAR_CONSIGNACION;
using Romsoft.GESTIONCLINICA.Entidades.FAR_CONSIGNACION;
using Romsoft.GESTIONCLINICA.WebApi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Romsoft.GESTIONCLINICA.WebApi.Controllers
{
    public class FAR_CONSIGNACIONController : BaseController
    {
        [HttpPost]
        public JsonResponse GetAllActives()
        {
            var jsonResponse = new JsonResponse { Success = true };

            try
            {

                var consigncionList = FAR_CONSIGNACIONBL.Instancia.GetAllActives();
                var consignacionDTOList = MapperHelper.Map<IEnumerable<FAR_CONSIGNACION>, IEnumerable<FAR_CONSIGNACIONDTO>>(consigncionList);
                jsonResponse.Data = consignacionDTOList;
            }
            catch (Exception ex)
            {
                LogError(ex);
                jsonResponse.Success = false;
                jsonResponse.Message = Mensajes.IntenteloMasTarde;
            }

            return jsonResponse;
        }
    }
}