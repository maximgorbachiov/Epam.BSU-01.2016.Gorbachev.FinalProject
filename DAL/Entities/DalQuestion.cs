using DAL.Interfaces.IEntities;

namespace DAL.Entities
{
    public class DalQuestion : IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string RightAnswer { get; set; }
        public int TestId { get; set; }
        public byte[] Image { get; set; }
    }
}
