using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace StatePatternInUnity
{
    public abstract class IRoomState
    {
        public void Initialize(RoomStateMachine stateMachine)
        {
            OnInitialized();
            OnActive();
        }

        public virtual void OnInitialized()
        {

        }

        public virtual void OnActive()
        {

        }

        public virtual void Update()
        {

        }

        public virtual IEnumerator Coroutine()
        {
            yield return null;
        }

        public virtual void OnEnded()
        {

        }

        public virtual async UniTask OnTransition()
        {
            await UniTask.Yield();
        }
    }
}