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

app.Run();
