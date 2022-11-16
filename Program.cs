using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World 2!");
app.MapGet("/user", () => "Luiz Gustavo");
app.MapGet("/userCom", () => new {Name = "Luiz Gustavo", Age = 35});
app.MapGet("/addHeader", (HttpResponse response) => response.Headers.Add("Teste", "Luiz Gustavo"));
app.MapGet("/addHeader2", (HttpResponse resp) => {
    resp.Headers.Add("test", "Luiz Gustavo");
    return new {name = "Luiz Gustavo", AggregateException = 35};
});

app.MapPost("/saveProduc", (Product prod) => {
    return prod.Code +  " - " + prod.Name;
});

app.MapGet("/getProduct", ( [FromQuery] string dateStart, string dateEnd) => {
    return dateStart + " - " + dateEnd;
});

app.MapGet("/getProduct/{code}", ([FromRoute] string code) => {
    return code;
});

app.Run();

public class Product{
    public String Code { get; set; }
    public String Name {get; set;} 


}