namespace MyApp.Web.Api.Bussiness.Entities
{
    public class Order
    {
        public Int32 IdClient { get; set; }
        public Int32 IdEmployee { get; set; }
        public DateTime DateOrder { get; set; }
        public Int32 State { get; set; }
        public long Id { get; set; }
    }
}