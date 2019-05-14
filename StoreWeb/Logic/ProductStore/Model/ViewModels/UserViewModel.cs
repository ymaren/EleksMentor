namespace Store.Logic.ProductStore.Models.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; internal set; }

        public string Login { get; internal set; }

        public string Password { get; internal set; }

        public string Name { get; internal set; }

        public UsersRoleViewModel Role { get; internal set; }
    }
}
