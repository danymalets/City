namespace Sources.ProjectServices.UserService
{
    public class Progress
    {
        public int CurrentLevel { get; set; } = 0;
        public StoryProgress StoryProgress { get; set; } = new();
    }
}