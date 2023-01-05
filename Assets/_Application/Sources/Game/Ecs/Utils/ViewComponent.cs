namespace Sources.Game.Ecs.Utils
{
    public struct ViewComponent<TView> where TView : IMono
    {
        public TView View;
    }
}