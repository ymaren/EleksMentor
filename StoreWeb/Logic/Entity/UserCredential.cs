namespace Store.Logic.Entity
{
    using System.Collections.Generic;

    public class UserCredential
    {
        public int Id { get; set; }

        public string NameCredential { get; set; }

        public string FullNameCredential { get; set; }

        public int ParentId { get; set; }

        public int Order { get; set; }

        public string Url { get; set; }

        public UserCredential Parent { get; set; }

        public ICollection<UserCredential> NestedCredentials { get; set; }
    }
}
