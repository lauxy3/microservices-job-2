namespace BookingAPI.Models
{
    public class BookingItem
    {
        public long Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public string? PickupPoint { get; set; }
        public string? Destination { get; set; }
        public string? Current_Location_Latitude { get; set; }
        public string? Current_Location_Longitude { get; set; }
        
    }
}