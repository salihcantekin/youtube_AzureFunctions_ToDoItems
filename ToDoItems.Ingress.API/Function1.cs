using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ToDoItems.Common;

namespace ToDoItems.Ingress.API;

public static class Function1
{
    [FunctionName("CreateToDo")]
    public static async Task<IActionResult> Run(
        //[HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "v1/CreateToDo")] HttpRequest req,
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "v1/CreateToDo")] ToDoItem todoItem,
        [ServiceBus(queueOrTopicName: "todoitemqueue", Connection = "ServiceBusConnStr")] IAsyncCollector<dynamic> serviceBusCollector,
        ILogger log)
    {
        //var bodyJson = await req.ReadAsStringAsync();
        //var todoItem = System.Text.Json.JsonSerializer.Deserialize<ToDoItem>(bodyJson);

        await serviceBusCollector.AddAsync(todoItem);

        return new OkObjectResult("ToDoItem successfully added to servicebus!");
    }
}
