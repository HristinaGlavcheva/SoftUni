namespace BorderControl.Contracts
{
    public interface ICitizen : IIdentifiable
    {
        string Name { get; }

        int Age { get; }
    }
}

