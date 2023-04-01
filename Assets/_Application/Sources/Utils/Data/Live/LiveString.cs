namespace Sources.Data.Live
{
    public class LiveString : LiveData<string>
    {
        public LiveString(string value = default) : base(value)
        {
        }
    }
}