namespace BorderControl.Contracts
{
    public interface ICitizen : IIdentifiable, IBirthable, IBuyer
    {
        string Name { get; }

        int Age { get; }
    }
}

