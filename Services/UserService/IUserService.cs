﻿using DisenioSistemas.Model.Enums;
using Model.DTO;
using Model.Entity;

namespace Services.UserService
{
    public interface IUserService
    {
        BedelDTO registrarBedel(BedelDTO bedel);
        List<BedelDTO> buscarBedel(string nombre, Turno? turno);
        Bedel crearNuevoBedel(BedelDTO bedelDTO);

    }
}
