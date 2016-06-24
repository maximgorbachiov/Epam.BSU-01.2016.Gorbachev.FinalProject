namespace BLL.Entities
{
    public class QuestionEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string RightAnswer { get; set; }
        public int TestId { get; set; }
        public byte[] Image { get; set; }
    }
}
