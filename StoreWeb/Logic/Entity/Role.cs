namespace Store.Logic.Entity
{
    using System.Collections.Generic;

    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
