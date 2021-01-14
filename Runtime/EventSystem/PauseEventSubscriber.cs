using UnityEngine;
using UnityEngine.Events;

namespace ActionCode.PauseSystem.EventSystem
{
    public sealed class PauseEventSubscriber : MonoBehaviour, IPauseable
    {
        public UnityEvent onPause = new UnityEvent();
        public UnityEvent onResume = new UnityEvent();

        private void OnEnable()
        {
            var hasListener = PauseListener.Find(out PauseListener pauseSystem);
            if (hasListener)
            {
                pauseSystem.Register(this);
            }
        }

        private void OnDisable()
        {
            var hasListener = PauseListener.Find(out PauseListener pauseSystem);
            if (hasListener)
            {
                pauseSystem.Unregister(this);
            }
        }

        public void Pause()
        {
            onPause?.Invoke();
        }

        public void Resume()
        {
            onResume?.Invoke();
        }


    }
}