namespace Animals
{
    public class Tomcat : Cat
    {
        private const string TomacatGender = "Male";

        public Tomcat(string name, int age) 
            : base(name, age, TomacatGender)
        {
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
