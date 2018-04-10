namespace DomainDrivenDesignArchitecture.Domain.CommandModel
{
    public class SaveUserCommand
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}
