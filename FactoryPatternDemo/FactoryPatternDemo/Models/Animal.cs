namespace FactoryPatternDemo.Models
{
    public abstract class Animal
    {
        public int Id { get; set; }
        public abstract string Speak();
    }
}
