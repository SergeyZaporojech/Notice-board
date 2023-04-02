namespace Notice_board.Entities
{
    public class Advert
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string ContactInformation { get; set; }
        public int Price { get; set; }
        public string? Foto { get; set; }
        public int CategoryId { get; set; }        

        //----------navigation property--------------
        public Category Category { get; set; }
    }
}
