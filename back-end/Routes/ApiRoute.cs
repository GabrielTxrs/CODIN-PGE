using back_end.Data;
using back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace back_end.Routes;

public static class ApiRoute
{
    public static void ApiRoutes(this WebApplication app)
    {
        app.MapGet("ola-mundo", () => "Ola mundo");
        app.MapGet("advogado", () => new Advogado(1, true, "oab",
            "nomePessoaFisica", "nomeSocial", "cpf", "celular", "telefone", "email", new DateOnly(2000, 1, 1)));

        app.MapGet("cliente",
            () => new Cliente(1, "nomePessoaFisica", "nomeSocial", "cpf", "celular",
                "telefone", "email", new DateOnly(2000, 1, 1)));

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
    }
}