using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/api/webhooks/glpi", (TicketDoGLPI ticket) =>
{
    Console.WriteLine($"Ticket recebido:\n - {ticket.Tipo}\n - {ticket.Id}\n - {ticket.GrupoTecnico}\n - {ticket.Titulo}\n - {ticket.Descricao}\n - {ticket.Url}");
    return Results.Ok();
});

app.Run();

public class TicketDoGLPI
{
    [JsonPropertyName("type")]
    public string Tipo { get; set; }
    public int Id {  get; set; }

    [JsonPropertyName("group")]
    public string GrupoTecnico { get; set; }

    [JsonPropertyName("title")]
    public string Titulo { get; set; }

    [JsonPropertyName("description")]
    public string Descricao { get; set; }

    public string Url { get; set; }
}

