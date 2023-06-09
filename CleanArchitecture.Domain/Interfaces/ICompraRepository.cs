﻿using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface ICompraRepository
    {
        Task<List<Compra>> listaBusquedaCompra(string? numeroDocumento, string? razonSocial);
        Task<int> Insert(Compra compra);

        void UpdateFieldsSave(Compra compra);

        Task Delete(int id);
    }
}
