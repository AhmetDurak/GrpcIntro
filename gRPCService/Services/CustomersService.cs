using Grpc.Core;

namespace gRPCService.Services;

public class CustomersService : Customer.CustomerBase
{
    private readonly ILogger<CustomersService> _logger;
    public CustomersService(ILogger<CustomersService> logger)
    {
        _logger = logger;
    }

    public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
    {
        CustomerModel output = new CustomerModel();

        if (request.UserId == 1)
        {
            output.FirstName = "Jamie";
            output.LastName = "Smith";
        }
        else if (request.UserId == 2)
        {
            output.FirstName = "Jane";
            output.LastName = "Doe";
        }
        else
        {
            output.FirstName = "Greg";
            output.LastName = "Thomas";
        }

        return Task.FromResult(output);
    }
    public override async Task GetNewCustomers(
            NewCustomerRequest request, 
            IServerStreamWriter<CustomerModel> responseStream, ServerCallContext context)
    {
        List<CustomerModel> customers = new List<CustomerModel>(){
        new CustomerModel{
            FirstName = "Tim",
            LastName = "Corey",
            EmailAddress = "tim@iamtimcorey.com",
            IsAlive = true
        },
        new CustomerModel{
            FirstName = "Sue",
            LastName = "Storm",
            EmailAddress = "sue@storm.net",
            IsAlive = false
        },
        new CustomerModel{
            FirstName = "Bilbo",
            LastName = "Baggins",
            EmailAddress = "bilbo@middleearth.net",
            IsAlive = false
        }
        };
        foreach (var cust in customers)
        {
            Task.Delay(1000).Wait();
            await responseStream.WriteAsync(cust);
        }
    }
}