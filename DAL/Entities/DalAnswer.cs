using DAL.Interfaces.IEntities;

namespace DAL.Entities
{
    public class DalAnswer : IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Number { get; set; }
        public int QuestionId { get; set; }
    }
}
