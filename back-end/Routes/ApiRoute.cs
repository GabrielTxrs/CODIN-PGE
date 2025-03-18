using back_end.Models;

namespace back_end.Routes;

public static class ApiRoute
{
    public static void ApiRoutes(this WebApplication app)
    {
        app.MapGet("ola-mundo", () => "Ola mundo");
        app.MapGet("advogado", () => new Advogado("oab", Guid.NewGuid(), Guid.NewGuid(), 
            Guid.NewGuid(), true));
    }
}