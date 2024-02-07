
using Grpc.Core;
using Grpc.Net.Client;
using gRPCService;

namespace gRPCClient;

public class Program
{
    static async Task Main(string[] args)
    {
        // var input = new HelloRequest{Name = "Ahmet"};
        var channel = GrpcChannel.ForAddress("http://localhost:5001");
        // var client = new Greeter.GreeterClient(channel);

        // var reply = await client.SayHelloAsync(input);

        // Console.WriteLine(reply.Message);


        var customerClient = new Customer.CustomerClient(channel);
        
        var clientRequested = new CustomerLookupModel { UserId = 1 };
        var customer = await customerClient.GetCustomerInfoAsync(clientRequested);

        Console.WriteLine($"{customer.FirstName} {customer.LastName}");

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("New Customer list:");

        using (var call = customerClient.GetNewCustomers(new NewCustomerRequest { }))
        {
            while (await call.ResponseStream.MoveNext())
            {
                var currentCustomer = call.ResponseStream.Current;

                Console.WriteLine($"{currentCustomer.FirstName} {currentCustomer.LastName}: {currentCustomer.EmailAddress}");
            }
        }


        Console.ReadLine();
    }
}