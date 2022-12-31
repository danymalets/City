namespace Sources.Utilities.StateTrees.States
{
    public interface IState
    {
        void Enter() =>
            OnEnter();
        
        void OnEnter();
    }
    
    public interface IState<TPayload>
    {
        void Enter(TPayload payload) =>
            OnEnter(payload);
        
        void OnEnter(TPayload payload);
    }
}