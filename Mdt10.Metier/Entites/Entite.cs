
namespace Mdt10.Metier.Entites
{
    public abstract class Entite
    {
        public virtual int Id { get; set; }
        public virtual int Version  { get; set; }
        public virtual TimeStamp TimeStamp { get; set; }
    }
}
