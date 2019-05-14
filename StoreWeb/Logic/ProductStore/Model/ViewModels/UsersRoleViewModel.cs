namespace Store.Logic.ProductStore.Models.ViewModels
{
    using System.Collections.Generic;

    public class UsersRoleViewModel
    {
        public int Id { get; internal set; }

        public string RoleName { get; internal set; }

        public IEnumerable<UserCredentialViewModel> RoleCredentials { get; internal set; }
    }
}
