using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;

namespace eCommerce.Infrastructure.Repositories;

public class UserRepository: IUsersRepository
{
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
       // Generate a new unique user id for the user
       user.Id = Guid.NewGuid();
       return user;
    }

    public async Task<ApplicationUser?> GetUserByNameAndPassword(string? email, string? password)
    {
       return new ApplicationUser
       {
           Id = Guid.NewGuid(),
           Email = email,
           Password = password,
           PersonName = "Muwonge Hassan",
           Gender = GenderOptions.Male.ToString()
       };
    }
}