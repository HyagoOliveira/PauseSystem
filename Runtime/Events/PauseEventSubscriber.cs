using UnityEngine;
using UnityEngine.Events;

namespace ActionCode.PauseSystem
{
    /// <summary>
    /// Subscriber class for <see cref="UnityEvent"/>.
    /// </summary>
    public sealed class PauseEventSubscriber : MonoBehaviour, IPauseable
    {
        [SerializeField, Tooltip("The Pause Settings asset reference.")]
        private PauseSettings settings;
        
        /// <summary>
        /// Unity events fired when the instance is paused.
        /// </summary>
        public UnityEvent OnPause { get; } = new();
        
        /// <summary>
        /// Unity events fired when the instance is resumed.
        /// </summary>
        public UnityEvent OnResume { get; } = new();

        private void OnEnable() => settings.Register(this);
        private void OnDisable() => settings.Unregister(this);

        public void Pause() => OnPause?.Invoke();
        public void Resume() => OnResume?.Invoke();
    }
}