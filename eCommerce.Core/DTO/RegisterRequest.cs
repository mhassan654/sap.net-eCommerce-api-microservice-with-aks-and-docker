namespace eCommerce.Core.DTO;

public record RegisterRequest(string? Email, string? Password,
    string? PersonalName, GenderOptions Gender);