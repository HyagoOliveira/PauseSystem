using UnityEngine;
using UnityEngine.Events;

namespace ActionCode.PauseSystem
{
    /// <summary>
    /// Subscriber class for <see cref="UnityEvent"/>.
    /// </summary>
    public sealed class PauseEventSubscriber : MonoBehaviour
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

        private void OnEnable ()
        {
            settings.OnPaused += HandlePaused;
            settings.OnResumed += HandleResumed;
        }

        private void OnDisable ()
        {
            settings.OnPaused -= HandlePaused;
            settings.OnResumed -= HandleResumed;
        }

        private void HandlePaused() => OnPause?.Invoke();
        private void HandleResumed() => OnResume?.Invoke();
    }
}