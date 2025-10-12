namespace LearnTop.Shared.Application.Cqrs;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
