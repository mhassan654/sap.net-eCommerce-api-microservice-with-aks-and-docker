namespace eCommerce.Core.DTO;

public record AuthenticationResponse(
    Guid Id,
    string? Email,
    string? PersonName,
    string? Gender,
    string? Token,
    bool Success
)
{
    //parameterless constructor
    public AuthenticationResponse() : this(
        default,
        default,
        default,
        default,
        default,
        default
    )
    {
        
    }
}
