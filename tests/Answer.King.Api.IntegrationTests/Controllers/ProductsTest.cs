using System.Net.Http.Json;
using Answer.King.Domain.Repositories.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;
using Assert = Xunit.Assert;

namespace Answer.King.Api.IntegrationTests.Controllers;
[TestClass]
public class ProductsTest
{
    [TestMethod]
    public async Task GetProducts_ReturnsList ()
    {
        var webAppFactory = new WebApplicationFactory<Program>();
        var httpClient = webAppFactory.CreateDefaultClient();

        var response = await httpClient.GetAsync("/api/products");
        var result = await response.Content.ReadAsStringAsync();
        var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(result);

        Assert.IsType<OkObjectResult>(result);
    }
}
