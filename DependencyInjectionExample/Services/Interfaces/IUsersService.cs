namespace DependencyInjectionExample.Services.Interfaces
{
    /* 
     * The upper level of abstraction of user withdrawal services.
     * Generics are used in this interface so that there are no problems defining methods for a particular service.
     */

    public interface IUsersService<T>
    {
        public Task<IEnumerable<T>> GetUsers();
    }
}
