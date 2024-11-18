public interface IMediator {
    void RegisterHandler<TRequest, TResponse>(IRequestHandler<TRequest, TResponse> handler);
    Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
}