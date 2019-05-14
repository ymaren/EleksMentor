namespace Store.Logic.ProductStore.Models.ModifyModels
{
    public class OrderHeaderModifyModel
    {
        public string Number { get; set; }
       
        public double Amount { get; set; }

        public int TypeId { get; set; }

        public int ToUserId { get; set; }
    }
}
