using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
using static System.Guid;
using Dapper; // Add this using directive

namespace eCommerce.Infrastructure.Repositories;

public class UserRepository : IUsersRepository
{
    private readonly DapperDbContext _dbContext;

    public UserRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        // Generate a new unique user id for the user
        user.Id = NewGuid();

        // sql query to insert user data into the "users" table
        string query = "INSERT INTO public.\"Users\"(\"Id\",\"Email\",\"PersonName\",\"Gender\",\"Password\") VALUES (@Id, @Email, @PersonName, @Gender,@Password)";

        int rowCountAffected = await _dbContext.DbConnection.ExecuteAsync(query, user);

        if (rowCountAffected > 0)
        {
            return user;
        }
        else
        {
            return null;
        }
    }

    public async Task<ApplicationUser?> GetUserByNameAndPassword(string? email, string? password)
    {

        //sql query to select a user by email and password
        const string query = "SELECT * FROM public.\"Users\" WHERE \"Email\" = @Email AND \"Password\" = @Password";
        var parameters = new { Email = email, Password = password };

        ApplicationUser? user = await 
            _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);
        //return new ApplicationUser
        //{
        //    Id = NewGuid(),
        //    Email = email,
        //    Password = password,
        //    PersonName = "Muwonge Hassan",
        //    Gender = GenderOptions.Male.ToString()
        //};

        return user;
    }
}
