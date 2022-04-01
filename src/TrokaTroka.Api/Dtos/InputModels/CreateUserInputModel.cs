namespace TrokaTroka.Api.Dtos.InputModels
{
    public class CreateUserInputModel
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}