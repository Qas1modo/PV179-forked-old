namespace BL.DTOs.BasicDtos
{
    public class ReviewPointDto
    {
        public ReviewDto Review { get; set; }

        public string Text { get; set; }

        public bool Positive { get; set; }
    }
}
