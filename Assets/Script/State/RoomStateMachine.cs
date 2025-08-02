using System.Threading.Tasks;
using UnityEngine;

namespace StatePatternInUnity
{
    public class RoomStateMachine : MonoBehaviour
    {
        private IRoomState _currentState;
        private IRoomState _previousState;
        public IRoomState State => _currentState;
        public IRoomState previousState => _previousState;

        public void Initialize(IRoomState startingState)
        {
            _currentState = startingState;
            startingState.Initialize(this);
        }

        public async Task ChangeState(IRoomState newState)
        {
            if (_currentState == null)
            {
                Initialize(newState);
                return;
            }

            await _currentState.OnTransition();
            _currentState.OnEnded();
            _previousState = _currentState;
            _currentState = newState;
            newState.Initialize(this);
        }

        private void Update()
        {
            _currentState?.Update();
        }

        internal bool IsCurrentState<T>(out T state) where T : IRoomState
        {
            state = _currentState as T;
            return state != null;
        }

        internal bool IsPreviousState<T>(out T state) where T : IRoomState
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