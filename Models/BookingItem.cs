namespace BookingAPI.Models
{
    public class BookingItem
    {
        public long Id { get; set; }
        public string? Date { get; set; }
        public string? Time { get; set; }
        public string? PickupPoint { get; set; }
        public string? Destination { get; set; }
        public string? Current_Location_Latitude { get; set; }
        public string? Current_Location_Longitude { get; set; }
        
    }
}