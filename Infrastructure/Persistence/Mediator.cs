public class Mediator : IMediator
{

    private readonly IServiceProvider _serviceProvider;
    public Mediator(IServiceProvider serviceProvider){
        _serviceProvider = serviceProvider;
    }
    
    Dictionary<Type, Object> _handlers = new();
    public void RegisterHandler<TRequest, TResponse>(IRequestHandler<TRequest, TResponse> handler)
    {
        var t = typeof(TRequest);
        _handlers[t] = handler;
    }

    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
    {
        var requestType = request.GetType();

        // Create the handler type dynamically
        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(requestType, typeof(TResponse));

        var handler = _serviceProvider.GetService(handlerType);
        if (handler == null) {
            
            throw new InvalidOperationException($"No handler registered for request type: {requestType.Name}");
        }
        // Check if the handler implements the expected interface
        else 
        {
            // Use reflection to invoke the Handle method
            var method = handlerType.GetMethod("Handle");
            if (method != null)
            {
                // Call Handle dynamically and await the result
                var task = (Task<TResponse>)method.Invoke(handler, new object[] { request });
                return await task;
            }
        }
        throw new InvalidOperationException($"No handler registered for request type: {requestType.Name}");

    }
}
