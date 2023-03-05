namespace Androsov.DataAccess.Entities
{
    public class Message
    {
        public int Id { get; set; }

        public required string Text { get; set; }

        public DateTime CreatedDate { get; set; }

        public required string UserId { get; set; }

        public ApplicationUser User { get; set; } = null!;
    }
}
