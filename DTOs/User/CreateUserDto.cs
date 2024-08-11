namespace salesAdmin.DTOs.User;

public class CreateUserDto
{
    public string Type { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Mail { get; set; } = "";
    public string Password { get; set; } = "";
}
