using CommandQuery.CQRS.Data;

namespace CommandQuery.CQRS.Queries;

public interface IQuery<T>
{
    List<T> Execute();
    
}

public interface IQuery
{
    User Execute();
}