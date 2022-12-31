namespace Sources.Infrastructure.Services.User
{
    public class User
    {
        public Progress Progress { get; private set; } = new ();
        public Preferences Preferences { get; private set; } = new ();
    }
}