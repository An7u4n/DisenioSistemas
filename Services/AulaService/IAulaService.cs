using Model.Abstract;
using Model.DTO;
using Model.Entity;

namespace Services.AulaService
{
    public interface IAulaService
    {
        AulaInformaticaDTO actualizarAulaInformatica(AulaInformaticaDTO aulaInformaticaDTO);
        AulaInformatica modificarAulaInformatica(AulaInformaticaDTO aulaDTO, AulaInformatica aulaExistente);
        AulaMultimediosDTO actualizarAulaMultimedios(AulaMultimediosDTO aulaMultimediosDTO);
        AulaMultimedios modificarAulaMultimedios(AulaMultimediosDTO aulaMultimediosDto, AulaMultimedios aulaMultimedios);
        AulaSinRecursosAdicionalesDTO actualizarAulaSinRecursosAdicionales(AulaSinRecursosAdicionalesDTO aulaSinRecursosAdicionalesDTO);

        AulaSinRecursosAdicionales modificarAulaSinRecursosAdicionales(AulaSinRecursosAdicionalesDTO aulaSinRecursosAdicionalesDTO, AulaSinRecursosAdicionales aulaSinRecursosAdicionales);

        
    }
}
