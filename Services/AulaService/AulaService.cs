using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DTO;
using Data.DAO;
using Model.Abstract;
using Microsoft.EntityFrameworkCore;
using Model.Entity;

namespace Services.AulaService
{
    public class AulaService : IAulaService
    {
        private readonly AulaDAO _aulaDAO;

        public AulaService(AulaDAO aulaDAO)
        {
            _aulaDAO = aulaDAO;
        }

        public AulaInformaticaDTO actualizarAulaInformatica(AulaInformaticaDTO aulaInformaticaDTO)
        {
            try
            {
                var aulaExistente = _aulaDAO.obtenerAulaInformatica(aulaInformaticaDTO.idAula);
                if (aulaExistente == null)
                {
                    throw new ArgumentException("No existe el aula");
                }

                if (!(aulaExistente is AulaInformatica))
                {
                    throw new ArgumentException("El aula no es del tipo adecuado.");
                }

                var aulaInformaticaActualizada = modificarAulaInformatica(aulaInformaticaDTO, (AulaInformatica)aulaExistente);

                var updatedAula = _aulaDAO.actualizarAulaInformatica(aulaInformaticaActualizada);

                return new AulaInformaticaDTO (
                   idAula: updatedAula.getIdAula(),
                   numero: updatedAula.getNumero(),
                   piso: updatedAula.getPiso(),
                   aireAcondicionado: updatedAula.getAireAcondicionado(),
                   estado: updatedAula.getEstado(),
                   capacidad: updatedAula.getCapacidad(),
                   tipoDePizarron: updatedAula.getTipoDePizarron(),
                   canion: updatedAula.getCanion(),
                   cantidadComputadoras:updatedAula.getCantidadComputadoras()
               );
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el Aula: " + ex.Message);
            }
        }


        public AulaInformatica modificarAulaInformatica(AulaInformaticaDTO aulaDTO, AulaInformatica aulaExistente)
        {
            if (aulaDTO.numero != aulaExistente.getNumero())
            {
                aulaExistente.setNumero(aulaDTO.numero);
            }

            if (aulaDTO.piso != aulaExistente.getPiso())
            {
                aulaExistente.setPiso(aulaDTO.piso);
            }

            if (aulaDTO.aireAcondicionado != aulaExistente.getAireAcondicionado())
            {
                aulaExistente.setAireAcondicionado(aulaDTO.aireAcondicionado);
            }

            if (aulaDTO.estado != aulaExistente.getEstado())
            {
                aulaExistente.setEstado(aulaDTO.estado);
            }

            if (aulaDTO.capacidad != aulaExistente.getCapacidad())
            {
                aulaExistente.setCapacidad(aulaDTO.capacidad);
            }

            if (aulaDTO.tipoDePizarron != aulaExistente.getTipoDePizarron())
            {
                aulaExistente.setTipoDePizarron(aulaDTO.tipoDePizarron);
            }

            if (aulaDTO.canion != aulaExistente.getCanion())
            {
                aulaExistente.setCanion(aulaDTO.canion);
            }

            if (aulaDTO.cantidadComputadoras != aulaExistente.getCantidadComputadoras())
            {
                aulaExistente.setCantidadComputadoras(aulaDTO.cantidadComputadoras);
            }

            return aulaExistente;
        }

        public AulaMultimediosDTO actualizarAulaMultimedios(AulaMultimediosDTO aulaMultimediosDTO)
        {
            try
            {
                var aulaExistente = _aulaDAO.obtenerAulaMultimedios(aulaMultimediosDTO.idAula);
                if (aulaExistente == null)
                {
                    throw new ArgumentException("No existe el aula");
                }
                var aulaMultimediosActualizada = modificarAulaMultimedios(aulaMultimediosDTO, aulaExistente);

                var updatedAula = _aulaDAO.actualizarAulaMultimedios(aulaMultimediosActualizada);

                return new AulaMultimediosDTO(
                    idAula: updatedAula.getIdAula(),
                    numero: updatedAula.getNumero(),
                    piso: updatedAula.getPiso(),
                    aireAcondicionado: updatedAula.getAireAcondicionado(),
                    estado: updatedAula.getEstado(),
                    capacidad: updatedAula.getCapacidad(),
                    tipoDePizarron: updatedAula.getTipoDePizarron(),
                    cantidadComputadoras: updatedAula.getCantidadComputadoras(),
                    canion: updatedAula.getCanion(),
                    poseeVentiladores: updatedAula.getPoseeVentiladores(),
                    televisor: updatedAula.getTelevisor()
                );
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el Aula: " + ex.Message);
            }
        }

        public AulaMultimedios modificarAulaMultimedios(AulaMultimediosDTO aulaMultimediosDto, AulaMultimedios aulaMultimedios)
        {
            if (aulaMultimediosDto.numero != aulaMultimedios.getNumero())
            {
                aulaMultimedios.setNumero(aulaMultimediosDto.numero);
            }

            if (aulaMultimediosDto.piso != aulaMultimedios.getPiso())
            {
                aulaMultimedios.setPiso(aulaMultimediosDto.piso);
            }

            if (aulaMultimediosDto.aireAcondicionado != aulaMultimedios.getAireAcondicionado())
            {
                aulaMultimedios.setAireAcondicionado(aulaMultimediosDto.aireAcondicionado);
            }

            if (aulaMultimediosDto.estado != aulaMultimedios.getEstado())
            {
                aulaMultimedios.setEstado(aulaMultimediosDto.estado);
            }

            if (aulaMultimediosDto.capacidad != aulaMultimedios.getCapacidad())
            {
                aulaMultimedios.setCapacidad(aulaMultimediosDto.capacidad);
            }

            if (aulaMultimediosDto.tipoDePizarron != aulaMultimedios.getTipoDePizarron())
            {
                aulaMultimedios.setTipoDePizarron(aulaMultimediosDto.tipoDePizarron);
            }

            if (aulaMultimediosDto.televisor != aulaMultimedios.getTelevisor())
            {
                aulaMultimedios.setTelevisor(aulaMultimediosDto.televisor);
            }

            if (aulaMultimediosDto.poseeVentiladores != aulaMultimedios.getPoseeVentiladores())
            {
                aulaMultimedios.setPoseeVentiladores(aulaMultimediosDto.poseeVentiladores);
            }

            if (aulaMultimediosDto.canion != aulaMultimedios.getCanion())
            {
                aulaMultimedios.setCanion(aulaMultimediosDto.canion);
            }

            if (aulaMultimediosDto.cantidadComputadoras != aulaMultimedios.getCantidadComputadoras())
            {
                aulaMultimedios.setCantidadComputadoras(aulaMultimediosDto.cantidadComputadoras);
            }

            return aulaMultimedios;
        }

        public AulaSinRecursosAdicionalesDTO actualizarAulaSinRecursosAdicionales(AulaSinRecursosAdicionalesDTO aulaSinRecursosAdicionalesDTO)
        {
            try
            {
                var aulaExistente = _aulaDAO.obtenerAulaSinRecursosAdicionales(aulaSinRecursosAdicionalesDTO.idAula);
                if (aulaExistente == null)
                {
                    throw new ArgumentException("No existe el aula");
                }
                var aulaSinRecursosAdicionalesActualizada = modificarAulaSinRecursosAdicionales(aulaSinRecursosAdicionalesDTO, aulaExistente);
                var updatedAula = _aulaDAO.actualizarAulaSinRecursosAdicionales(aulaSinRecursosAdicionalesActualizada);
                return new AulaSinRecursosAdicionalesDTO(
                    idAula: updatedAula.getIdAula(),
                    numero: updatedAula.getNumero(),
                    piso: updatedAula.getPiso(),
                    aireAcondicionado: updatedAula.getAireAcondicionado(),
                    estado: updatedAula.getEstado(),
                    capacidad: updatedAula.getCapacidad(),
                    tipoDePizarron: updatedAula.getTipoDePizarron(),
                    poseeVentiladores: updatedAula.getPoseeVentiladores()
                );
                
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el Aula: " + ex.Message);
            }
        }

        public AulaSinRecursosAdicionales modificarAulaSinRecursosAdicionales(AulaSinRecursosAdicionalesDTO aulaSinRecursosAdicionalesDTO, AulaSinRecursosAdicionales aulaSinRecursosAdicionales)
        {
            if (aulaSinRecursosAdicionalesDTO.numero != aulaSinRecursosAdicionales.getNumero())
            {
                aulaSinRecursosAdicionales.setNumero(aulaSinRecursosAdicionalesDTO.numero);
            }
            if (aulaSinRecursosAdicionalesDTO.piso != aulaSinRecursosAdicionales.getPiso())
            {
                aulaSinRecursosAdicionales.setPiso(aulaSinRecursosAdicionalesDTO.piso);
            }
            if (aulaSinRecursosAdicionalesDTO.aireAcondicionado != aulaSinRecursosAdicionales.getAireAcondicionado())
            {
                aulaSinRecursosAdicionales.setAireAcondicionado(aulaSinRecursosAdicionalesDTO.aireAcondicionado);
            }
            if (aulaSinRecursosAdicionalesDTO.estado != aulaSinRecursosAdicionales.getEstado())
            {
                aulaSinRecursosAdicionales.setEstado(aulaSinRecursosAdicionalesDTO.estado);
            }
            if (aulaSinRecursosAdicionalesDTO.capacidad != aulaSinRecursosAdicionales.getCapacidad())
            {
                aulaSinRecursosAdicionales.setCapacidad(aulaSinRecursosAdicionalesDTO.capacidad);
            }
            if (aulaSinRecursosAdicionalesDTO.tipoDePizarron != aulaSinRecursosAdicionales.getTipoDePizarron())
            {
                aulaSinRecursosAdicionales.setTipoDePizarron(aulaSinRecursosAdicionalesDTO.tipoDePizarron);
            }
            if (aulaSinRecursosAdicionalesDTO.poseeVentiladores != aulaSinRecursosAdicionales.getPoseeVentiladores())
            {
                aulaSinRecursosAdicionales.setPoseeVentiladores(aulaSinRecursosAdicionalesDTO.poseeVentiladores);
            }
            return aulaSinRecursosAdicionales;
        }
    }
}
