using Sources.Infrastructure.Services.CoroutineRunner;

namespace Sources.Utilities.StateTrees.Base
{
    public abstract class StateBase
    {
        protected readonly NodeStateBase _parent;

        protected readonly CoroutineContext _coroutineContext;

        
        protected StateBase(NodeStateBase parent)
        {
            _parent = parent;
            _coroutineContext = new CoroutineContext();
        }

        public void Exit()
        {
            _coroutineContext.StopAllCoroutines();
            ExitInternal();
        }

        protected abstract void ExitInternal();
    }
}