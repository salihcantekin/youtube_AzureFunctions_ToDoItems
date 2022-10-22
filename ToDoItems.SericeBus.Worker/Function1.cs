using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using ToDoItems.Common;

namespace ToDoItems.SericeBus.Worker;

public class Function1
{
    //[FunctionName("Function1")]
    //public async Task Run([ServiceBusTrigger("todoitemqueue", Connection = "ServiceBusConnStr")] ToDoItem todoItem,
    //                [CosmosDB(databaseName: "TBCosmosDB", collectionName: "ToDoItemsContainer",
    //                           ConnectionStringSetting = "CosmosDbConnStr" )] IAsyncCollector<dynamic> todoItemsCollector,
    //                ILogger log)
    //{
    //    log.LogInformation($"C# ServiceBus queue trigger function processed message: {todoItem}");

    //    await todoItemsCollector.AddAsync(todoItem);
    //}


    [FunctionName("Function2")]
    public void Run2([ServiceBusTrigger("todoitemqueue", Connection = "ServiceBusConnStr")] ToDoItem todoItem,
                    [CosmosDB(databaseName: "TBCosmosDB", collectionName: "ToDoItemsContainer",
                               ConnectionStringSetting = "CosmosDbConnStr" )] out dynamic todoItemOut,
                    ILogger log)
    {
        log.LogInformation($"C# ServiceBus queue trigger function processed message: {todoItem}");

        todoItemOut = todoItem;
    }
}
