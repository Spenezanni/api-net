using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/user", () => "Luiz Gustavo");
app.MapGet("/userCom", () => new {Name = "Luiz Gustavo", Age = 35});
app.MapGet("/addHeader", (HttpResponse response) => response.Headers.Add("Teste", "Luiz Gustavo"));
app.MapGet("/addHeader2", (HttpResponse resp) => {
    resp.Headers.Add("test", "Luiz Gustavo");
    return new {name = "Luiz Gustavo", Age = 35};
});

app.MapPost("/saveProduct", (Product prod) => {
    ProductRepository.Add(prod);
});

app.MapGet("/getProduct", ( [FromQuery] string dateStart, string dateEnd) => {
    return dateStart + " - " + dateEnd;
});

app.MapGet("/getProduct/{code}", ([FromRoute] string code) => {
    var product = ProductRepository.GetByCode(code);
    return product;
});

app.MapGet("/getProducByHeader", (HttpRequest req) => {
    return req.Headers["product-code"].ToString();
});

app.MapPut("/editProduct", (Product prod) => {
   var prodSave = ProductRepository.GetByCode(prod.Code);
   prodSave.Name = prod.Name;
   //ProductRepository.Add(prodSave);
   //return prodSave;
});

app.MapDelete("/deleteProduct/{code}", ([FromRoute] string code) => {
    var prodget = ProductRepository.GetByCode(code);
    ProductRepository.Remove(prodget);
});

app.Run();


public class Product{
    public String Code { get; set; }
    public String Name {get; set;} 

}


public static class ProductRepository {
    public static List<Product> Products {get; set;}

    public static void Add(Product prop){
        if(Products == null){
            Products = new List<Product>();
            Products.Add(prop);
        }
    }
    
    public static Product GetByCode(string code){
        return Products.FirstOrDefault(p => p.Code == code);
   
    }

    public static void Remove(Product prop) {
        Products.Remove(prop);
    }
    
}