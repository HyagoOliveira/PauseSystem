using UnityEngine;
using UnityEngine.Events;

namespace ActionCode.PauseSystem
{
    /// <summary>
    /// Pause class for <see cref="UnityEvent"/>.
    /// <para>
    /// It will fire <see cref="OnPause"/> and <see cref="OnResume"/> events.
    /// </para>
    /// </summary>
    public sealed class PauseUnityEvent : MonoBehaviour
    {
        /// <summary>
        /// Unity events fired when the instance is paused.
        /// </summary>
        public UnityEvent OnPause { get; } = new();

        /// <summary>
        /// Unity events fired when the instance is resumed.
        /// </summary>
        public UnityEvent OnResume { get; } = new();

        private void OnEnable()
        {
            PauseManager.OnPaused += HandlePaused;
            PauseManager.OnResumed += HandleResumed;
        }

        private void OnDisable()
        {
            PauseManager.OnPaused -= HandlePaused;
            PauseManager.OnResumed -= HandleResumed;
        }

        private void HandlePaused() => OnPause?.Invoke();
        private void HandleResumed() => OnResume?.Invoke();
    }
}