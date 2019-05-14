namespace Store.Logic.Entity
{
    using System.Collections.Generic;

    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public ICollection<Role> Roles { get; set; }

        public ICollection<OrderHeader> OrderHeaders { get; set; }
    }
}
