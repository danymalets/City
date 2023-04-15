namespace _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Views
{
    public interface IAnimator
    {
        void Play(int moveBlendTree, int baseLayer, float value);
        void SetBool(int die, bool b);
        void SetFloat(int speed, float i);
        int GetLayerIndex(string baseLayer);
    }
}