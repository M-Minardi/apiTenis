﻿using apiTenis.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace apiTenis.Helpers
{
    public static class HttpContextExtensions
    {
        public async static Task InsertarParametrosPaginacion<T>(this HttpContext httpContext,
            IQueryable<T> queryable, int cantidadRegistrosPorPagina)
        {
            double cantidad = await queryable.CountAsync();
            double cantidadPaginas = Math.Ceiling(cantidad / cantidadRegistrosPorPagina);
            httpContext.Response.Headers.Append("cantidadPaginas", cantidadPaginas.ToString());
        }
    }
}