namespace Notes.Domain1
{
    public class Note
    {
        public Guid UserId { get; set; }
        public Guid NoteId { get; set; }
        public string NoteName { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set;}
    }
}