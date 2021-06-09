using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBlazor.Data.Models;

namespace TesteBlazor.Data.Services
{
    public class CompraService
    {
        private readonly AcessoDB _context;

        public CompraService(AcessoDB _context)
        {
            this._context = _context;
        }

        public async Task<Compra> CreateCompra(Compra compra)
        {
            await _context.Compras.AddAsync(compra);
            await _context.SaveChangesAsync();
            return compra;
        }

        public async Task<IEnumerable<Compra>> GetCompras()
        {
            return await _context.Compras.ToListAsync();
        }
    }
}
