namespace Domain.Dtos.Users;

public class UpdateUserDto:CreateUserDto
{
    public int Id { get; set; }
    public UpdateUserDto(CreateUserDto createUserDto,int Id)
    {
        this.Id = Id;
        this.Name = createUserDto.Name;
        this.Email = createUserDto.Email;
        this.Password = createUserDto.Password;
        this.RoleId = createUserDto.RoleId;
    }
}
