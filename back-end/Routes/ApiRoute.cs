using back_end.Data;
using back_end.Models;
using Microsoft.EntityFrameworkCore;

namespace back_end.Routes;

public static class ApiRoute
{
    public static void ApiRoutes(this WebApplication app)
    {
        app.MapGet("ola-mundo", () => "Ola mundo");
        app.MapGet("advogado", () => new Advogado(Guid.NewGuid(), true, "oab",
            "nomePessoaFisica", "nomeSocial", "cpf", "celular", "telefone", "email", new DateOnly(2000, 1, 1)));

        app.MapGet("cliente",
            () => new Cliente(Guid.NewGuid(), "nomePessoaFisica", "nomeSocial", "cpf", "celular",
                "telefone", "email", new DateOnly(2000, 1, 1)));
        // {
        //     "idAdvogado": "4bcdaac6-f56d-4d33-839a-dedd5da7c449",
        //     "idUsuario": "a0eb3cea-e725-4479-afbe-e21ef593ec50",
        //     "isProcurador": true,
        //     "oab": "oab",
        //     "nomePessoaFisica": "nomePessoaFisica",
        //     "nomeSocial": "nomeSocial",
        //     "cpf": "cpf",
        //     "celular": "celular",
        //     "telefone": "telefone",
        //     "email": "email",
        //     "dataNascimento": "2000-01-01"
        // }
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

        // Get Cliente por ID 
        app.MapGet("/get-cliente/{id:guid}", async (AppDbContext db, Guid id) =>
            await db.Clientes.FindAsync(id)
                is { } cliente
                ? Results.Ok(cliente)
                : Results.NotFound());

        // Update Cliente por ID
        app.MapPut("/update-cliente/{id:guid}", async (AppDbContext db, Guid id, Cliente inputCliente) =>
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

        // Delete Cliente por ID
        app.MapDelete("/clientes/{id:guid}", async (AppDbContext db, Guid id) =>
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