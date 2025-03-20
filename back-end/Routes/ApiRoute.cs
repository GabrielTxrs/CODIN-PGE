using back_end.Data;
using back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace back_end.Routes;

public static class ApiRoute
{
    public static void ApiRoutes(this WebApplication app)
    {
        // Adicionar Cliente
        app.MapPost("/add-cliente", async (AppDbContext db, Cliente cliente) =>
        {
            db.Clientes.Add(cliente);
            await db.SaveChangesAsync();
            return Results.Created($"/clientes/{cliente.IdCliente}", cliente);
        });

        // Get All Clientes
        app.MapGet("/get-cliente", async (AppDbContext db) =>
            await db.Clientes.ToListAsync());
        
        app.MapGet("/get-cliente-filtro", async (AppDbContext db, int? id, string? nome) =>
        {
            var query = db.Clientes.AsQueryable();
            
            if (id.HasValue)
            {
                query = query.Where(c => c.IdCliente == id.Value);
            }

            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(c => c.NomePessoaFisica.Contains(nome));
            }

            var clientes = await query.ToListAsync();
            return clientes.Any() ? Results.Ok(clientes) : Results.NotFound();
        });
        
        // Update Cliente por ID
        app.MapPut("/update-cliente/{id}", async (AppDbContext db, int id, Cliente inputCliente) =>
        {
            var cliente = await db.Clientes.FindAsync(id);

            if (cliente is null) return Results.NotFound();

            cliente.NomePessoaFisica = inputCliente.NomePessoaFisica;
            cliente.NomeSocial = inputCliente.NomeSocial;
            cliente.Cpf = inputCliente.Cpf;
            cliente.Celular = inputCliente.Celular;
            cliente.Telefone = inputCliente.Telefone;
            cliente.Email = inputCliente.Email;
            cliente.DataNascimento = inputCliente.DataNascimento;

            await db.SaveChangesAsync();

            return Results.NoContent();
        });

        // Deletar Cliente por ID
        app.MapDelete("/remover-cliente/{id}", async (AppDbContext db, int? id) =>
        {
            if (await db.Clientes.FindAsync(id) is { } cliente)
            {
                db.Clientes.Remove(cliente);
                await db.SaveChangesAsync();
                return Results.Ok(cliente);
            }

            return Results.NotFound();
        });
        
        // Adicionar Advogado
        app.MapPost("/add-advogado", async (AppDbContext db, Advogado advogado) =>
        {
            db.Advogados.Add(advogado);
            await db.SaveChangesAsync();
            return Results.Created($"/add-advogado/{advogado.IdAdvogado}", advogado);
        });

        // Get All Advogados
        app.MapGet("/get-advogado", async (AppDbContext db) =>
            await db.Advogados.ToListAsync());
        
        app.MapGet("/get-advogado-filtro", async (AppDbContext db, int? id, string? nome) =>
        {
            var query = db.Advogados.AsQueryable();
            
            if (id.HasValue)
            {
                query = query.Where(c => c.IdAdvogado == id.Value);
            }

            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(c => c.NomePessoaFisica.Contains(nome));
            }

            var advogados = await query.ToListAsync();
            return advogados.Any() ? Results.Ok(advogados) : Results.NotFound();
        });
        
        // Update Advogado por ID
        app.MapPut("/update-advogado/{id}", async (AppDbContext db, int id, Advogado inputAdvogado) =>
        {
            var advogado = await db.Advogados.FindAsync(id);

            if (advogado is null) return Results.NotFound();

            advogado.Oab = inputAdvogado.Oab;
            advogado.IsProcurador = inputAdvogado.IsProcurador; 
            advogado.NomePessoaFisica = inputAdvogado.NomePessoaFisica;
            advogado.NomeSocial = inputAdvogado.NomeSocial;
            advogado.Cpf = inputAdvogado.Cpf;
            advogado.Celular = inputAdvogado.Celular;
            advogado.Telefone = inputAdvogado.Telefone;
            advogado.Email = inputAdvogado.Email;
            advogado.DataNascimento = inputAdvogado.DataNascimento;

            await db.SaveChangesAsync();

            return Results.NoContent();
        });

        // Deletar Advogado por ID
        app.MapDelete("/remover-advogado/{id}", async (AppDbContext db, int? id) =>
        {
            if (await db.Advogados.FindAsync(id) is { } advogado)
            {
                db.Advogados.Remove(advogado);
                await db.SaveChangesAsync();
                return Results.Ok(advogado);
            }

            return Results.NotFound();
        });
        
    }
}