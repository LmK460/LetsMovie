namespace Domain.Entities
{
    public class CommentDTO
    {
        public string ImdbId { get; set; }
        public string UserName { get; set; }

        public string Commentary { get; set; }

        public int? PrincipalbId { get; set; }
    }
}
