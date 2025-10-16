namespace Login.Api.Models;

public class UserDetail
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Role { get; set; } = default!;
    public DateTimeOffset Created_At { get; set; }
    public DateTimeOffset Updated_At { get; set; }
    public bool IsActive { get; set; }
}
