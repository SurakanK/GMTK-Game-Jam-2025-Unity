using UnityEngine;

namespace StatePatternInUnity
{
    public class StateMachine : MonoBehaviour
    {
        private IState _currentState;
        private IState _previousState;
        public IState State => _currentState;
        public IState previousState => _previousState;

        public void Initialize(IState startingState)
        {
            _currentState = startingState;
            startingState.Initialize(this);
        }

        public void ChangeState(IState newState)
        {
            if (_currentState == null)
                Initialize(newState);

            if (newState.GetType() == _currentState.GetType())
                return;

            _currentState.OnEnded();
            _previousState = _currentState;
            _currentState = newState;
            newState.Initialize(this);
        }

        private void Update()
        {
            _currentState?.Update();
        }

        internal bool IsCurrentState<T>(out T state) where T : IState
        {
            state = _currentState as T;
            return state != null;
        }

        internal bool IsPreviousState<T>(out T state) where T : IState
        {
            state = _previousState as T;
            return state != null;
        }

        void OnDestroy()
        {
            _currentState = null;
            _previousState = null;
        }
    }
}