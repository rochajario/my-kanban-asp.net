namespace Domain.Interfaces
{
    public interface IDto<TEntity, TState> where TState : Enum
    {
        TEntity ToEntity(TState? state = default);
    }
}
