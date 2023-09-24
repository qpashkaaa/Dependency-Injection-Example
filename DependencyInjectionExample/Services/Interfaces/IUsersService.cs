namespace DependencyInjectionExample.Services.Interfaces
{
    /* 
     * Верхний уровень абстракции сервисов по выводу пользователей. 
     * В данном интерфейсе используются дженерики, чтобы не было проблем определением методов для конкретного сервиса.
     */

    public interface IUsersService<T>
    {
        public Task<IEnumerable<T>> GetUsers();
    }
}
