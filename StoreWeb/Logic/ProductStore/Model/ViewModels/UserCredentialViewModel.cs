namespace Store.Logic.ProductStore.Models.ViewModels
{
    public class UserCredentialViewModel
    {
        public int Id { get; internal set; }

        public string NameCredential { get; internal set; }

        public string FullNameCredential { get; internal set; }

        public int? ParentCredentialid { get; internal set; }

        public int Order { get; internal set; }

        public string Url { get; internal set; }

    }
}
