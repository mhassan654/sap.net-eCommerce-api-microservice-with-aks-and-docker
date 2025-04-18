using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContracts;

/// <summary>
/// Contract to be implemented by UserRepository that contains data access
/// logic of users data store
/// </summary>
public interface IUsersRepository
{
    /// <summary>
    /// Method to add a user to the data store and return the added user
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<ApplicationUser?> AddUser(ApplicationUser user);

    
    /// <summary>
    /// Method to retrieve exisitng user by thier email and password
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<ApplicationUser?> GetUserByNameAndPassword(string? email, string? password);
}