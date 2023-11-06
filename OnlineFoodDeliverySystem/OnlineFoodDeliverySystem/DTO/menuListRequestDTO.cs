namespace OnlineFoodDeliverySystem.DTO
{
    public class menuListRequestDTO
    {
        public string Item_Name { get; set; }
        public string Price { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }

        public int Restaurant_id { get; set; }
    }
}
