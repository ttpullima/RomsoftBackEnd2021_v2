﻿using Newtonsoft.Json;
using Romsoft.GESTIONCLINICA.Business.Logic.Tablas;
using Romsoft.GESTIONCLINICA.Entidades.ADM_PACIENTE;
using Romsoft.GESTIONCLINICA.Entidades;
using Romsoft.GESTIONCLINICA.DTO.TABLAS.ADM_PACIENTE;
using Romsoft.GESTIONCLINICA.WebApi.Core;
using Romsoft.GESTIONCLINICA.Common;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Romsoft.GESTIONCLINICA.DTO.AutoMapper;

namespace Romsoft.GESTIONCLINICA.WebApi.Controllers
{
    public class ADM_PACIENTEController : BaseController
    {
        [HttpPost]
        public JsonResponse Add(ADM_PACIENTEDTO pacienteDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };
            try
            {
                //int resultado = 0;
                var paciente = MapperHelper.Map<ADM_PACIENTEDTO, ADM_PACIENTE>(pacienteDTO);

                if (!ADM_PACIENTEBL.Instancia.Exists(paciente))
                {
                    var resultado = ADM_PACIENTEBL.Instancia.Add2(paciente);

                    if (resultado.Item1 > 0)
                    {
                        jsonResponse.Message = Mensajes.RegistroSatisfactorio;
                    }
                    else
                    {
                        jsonResponse.Warning = true;
                        jsonResponse.Message = resultado.Item2; // Mensajes.RegistroFallido;
                    }
                }
                else
                {
                    jsonResponse.Warning = true;
                    jsonResponse.Message = Mensajes.YaExisteRegistro;
                }

                LogBL.Instancia.Add(new Log
                {
                    Accion = Mensajes.Add,
                    Controlador = Mensajes.UsuarioController,
                    Identificador = 0,
                    Mensaje = jsonResponse.Message,
                    Usuario = pacienteDTO.UsuarioCreacion,
                    Objeto = JsonConvert.SerializeObject(pacienteDTO)
                });
            }
            catch (Exception ex)
            {
                LogError(ex);
                jsonResponse.Success = false;
                jsonResponse.Message = Mensajes.IntenteloMasTarde;

                LogBL.Instancia.Add(new Log
                {
                    Accion = Mensajes.Add,
                    Controlador = Mensajes.UsuarioController,
                    Identificador = 0,
                    Mensaje = ex.Message,
                    Usuario = pacienteDTO.UsuarioCreacion,
                    Objeto = JsonConvert.SerializeObject(pacienteDTO)
                });
            }

            return jsonResponse;
        }

        [HttpPost]
        public JsonResponse GetAllFilters(ADM_PACIENTEDTO pacienteDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };

            try
            {
                var paciente = MapperHelper.Map<ADM_PACIENTEDTO, ADM_PACIENTE>(pacienteDTO);

                var pacienteList = ADM_PACIENTEBL.Instancia.GetAllFilters(paciente);
                var pacienteDTOList = MapperHelper.Map<IEnumerable<ADM_PACIENTE>, IEnumerable<ADM_PACIENTEDTO>>(pacienteList);
                jsonResponse.Data = pacienteDTOList;
            }
            catch (Exception ex)
            {
                LogError(ex);
                jsonResponse.Success = false;
                jsonResponse.Message = Mensajes.IntenteloMasTarde;
            }

            return jsonResponse;
        }

        [HttpPost]
        public JsonResponse Update(ADM_PACIENTEDTO pacienteDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };
            try
            {
                var paciente = MapperHelper.Map<ADM_PACIENTEDTO, ADM_PACIENTE>(pacienteDTO);
                int resultado = ADM_PACIENTEBL.Instancia.Update(paciente);

                if (resultado > 0)
                {
                    jsonResponse.Message = Mensajes.ActualizacionSatisfactoria;
                }
                else
                {
                    jsonResponse.Warning = true;
                    jsonResponse.Message = Mensajes.ActualizacionFallida;
                }

                LogBL.Instancia.Add(new Log
                {
                    Accion = Mensajes.Update,
                    Controlador = Mensajes.UsuarioController,
                    Identificador = resultado,
                    Mensaje = jsonResponse.Message,
                    Usuario = pacienteDTO.UsuarioModificacion,
                    Objeto = JsonConvert.SerializeObject(pacienteDTO)
                });
            }
            catch (Exception ex)
            {
                LogError(ex);
                jsonResponse.Success = false;
                jsonResponse.Message = Mensajes.IntenteloMasTarde;

                LogBL.Instancia.Add(new Log
                {
                    Accion = Mensajes.Update,
                    Controlador = Mensajes.UsuarioController,
                    Identificador = 0,
                    Mensaje = ex.Message,
                    Usuario = pacienteDTO.UsuarioModificacion,
                    Objeto = JsonConvert.SerializeObject(pacienteDTO)
                });
            }

            return jsonResponse;
        }

        [HttpPost]
        public JsonResponse Delete(ADM_PACIENTEDTO pacienteDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };
            try
            {
                var paciente = MapperHelper.Map<ADM_PACIENTEDTO, ADM_PACIENTE>(pacienteDTO);
                int resultado = ADM_PACIENTEBL.Instancia.Delete(paciente);

                if (resultado > 0)
                {
                    jsonResponse.Message = Mensajes.EliminacionSatisfactoria;
                }
                else
                {
                    jsonResponse.Warning = true;
                    jsonResponse.Message = Mensajes.EliminacionFallida;
                }
                LogBL.Instancia.Add(new Log
                {
                    Accion = Mensajes.Delete,
                    Controlador = Mensajes.UsuarioController,
                    Identificador = resultado,
                    Mensaje = jsonResponse.Message,
                    Usuario = pacienteDTO.UsuarioModificacion,
                    Objeto = JsonConvert.SerializeObject(pacienteDTO)
                });

            }
            catch (Exception ex)
            {
                LogError(ex);
                jsonResponse.Success = false;
                jsonResponse.Message = Mensajes.IntenteloMasTarde;

                LogBL.Instancia.Add(new Log
                {
                    Accion = Mensajes.Delete,
                    Controlador = Mensajes.UsuarioController,
                    Identificador = 0,
                    Mensaje = ex.Message,
                    Usuario = pacienteDTO.UsuarioModificacion,
                    Objeto = JsonConvert.SerializeObject(pacienteDTO)
                });
            }

            return jsonResponse;
        }

        [HttpPost]
        public JsonResponse GetById(ADM_PACIENTEDTO pacienteDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };

            try
            {
                var paciente = MapperHelper.Map<ADM_PACIENTEDTO, ADM_PACIENTE>(pacienteDTO);

                var pacienteList = ADM_PACIENTEBL.Instancia.GetById(paciente);
                var pacienteDTOList = MapperHelper.Map<IEnumerable<ADM_PACIENTE>, IEnumerable<ADM_PACIENTEDTO>>(pacienteList);
                jsonResponse.Data = pacienteDTOList;
            }
            catch (Exception ex)
            {
                LogError(ex);
                jsonResponse.Success = false;
                jsonResponse.Message = Mensajes.IntenteloMasTarde;
            }

            return jsonResponse;
        }

        /// <summary>
        /// Consulta Datos Paciente/Atenciones
        /// </summary>
        /// <param name="t_dato">Dato a consultar</param>
        /// <param name="tipo_dato">Tipo de dato a consultar F/P/H/C</param>
        /// <returns>Objeto pacienteDTOList con datos del Paciente y Atenciones</returns>
        /// <response code="200">estado OK</response>
        [HttpPost]
        public JsonResponse GetAllPacienteAtencionFilters(ADM_PACIENTEATENCIONReqDTO pacienteDTO)
        {
            var jsonResponse = new JsonResponse { Success = true };

            try
            {
                //var paciente = MapperHelper.Map<ADM_PACIENTEDTO, ADM_PACIENTE>(pacienteDTO);

                var pacienteList = ADM_PACIENTEBL.Instancia.GetAllPacienteAtencionFilters(pacienteDTO.t_dato.ToUpper(), pacienteDTO.tipo_dato);
                var pacienteDTOList = MapperHelper.Map<IEnumerable<ADM_PACIENTEATENCIONRes>, IEnumerable<ADM_PACIENTEATENCIONResDTO>>(pacienteList);

                if(pacienteList.Count <=0)
                {
                    jsonResponse.Message = "No existe información con los datos enviados.";
                }

                jsonResponse.Data = pacienteDTOList;
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
