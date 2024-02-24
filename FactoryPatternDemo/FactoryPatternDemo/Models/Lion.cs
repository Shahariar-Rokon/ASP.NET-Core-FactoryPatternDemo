namespace FactoryPatternDemo.Models
{
    public class Lion:Animal
    {
        public override string Speak()
        {
            return "Roar";
        }
    }
    public class Elephant : Animal
    {
        public override string Speak()
        {
            return "Trumpet!";
        }
    }
}
