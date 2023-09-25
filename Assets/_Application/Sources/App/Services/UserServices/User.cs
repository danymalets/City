namespace Sources.App.Services.UserServices
{
    public class User
    {
        public bool IsRemoveAds { get; set; } = false;
        public Progress Progress { get; private set; } = new ();
        public Wallet Wallet { get; } = new();
        public Preferences Preferences { get; private set; } = new ();
    }
}