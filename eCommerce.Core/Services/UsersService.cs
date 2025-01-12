using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

internal class UsersService: IUsersService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;

    public UsersService(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }
    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
       ApplicationUser? user = await _usersRepository.GetUserByNameAndPassword(loginRequest.Email, loginRequest.Password);

       if (user == null)
       {
           return null;
       }

       // return new AuthenticationResponse(
       //     user.Id, 
       //     user.Email, 
       //     user.PersonName,
       //     user.Gender,
       //     "token",
       //     Success: true);

       return _mapper.Map<AuthenticationResponse>(user) with
       {
           Success = true, Token = "token"
       };
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
    {
        // create a new applicationUser object from registerRequest
        ApplicationUser user = new ApplicationUser()
        {
            PersonName = registerRequest.PersonName,
            Email = registerRequest.Email,
            Password = registerRequest.Password,
            Gender = registerRequest.Gender.ToString()
        };

        ApplicationUser? regApplicationUser = await _usersRepository.AddUser(user);
        if (regApplicationUser ==null)
        {
            return null;
        }
        
        // return success response
        // return new AuthenticationResponse(
        //     regApplicationUser.Id,
        //     regApplicationUser.Email,
        //     regApplicationUser.PersonName,
        //     regApplicationUser.Gender,
        //     "token",Success:true);
        
        return _mapper.Map<AuthenticationResponse>(regApplicationUser) with
        {
            Success = true, Token = "token"
        };
    }
}