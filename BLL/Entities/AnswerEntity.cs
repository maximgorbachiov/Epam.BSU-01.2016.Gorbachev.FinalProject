namespace BLL.Entities
{
    public class AnswerEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Number { get; set; }
        public int QuestionId { get; set; }
    }
}
