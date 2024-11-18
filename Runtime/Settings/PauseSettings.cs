using System;
using UnityEngine;
using System.Collections;
using ActionCode.AwaitableCoroutines;

namespace ActionCode.PauseSystem
{
    /// <summary>
    /// Settings class for the Pause System.
    /// Use it to subscribe to <see cref="OnPaused"/> and <see cref="OnResumed"/> events.
    /// </summary>
    [CreateAssetMenu(fileName = "PauseSettings", menuName = "ActionCode/Pause Manager/Settings", order = 110)]
    public sealed class PauseSettings : ScriptableObject
    {
        [field: SerializeField, Tooltip("Whether to stop the TimeScale when paused.")]
        public bool StopTimeScale { get; private set; } = true;

        /// <summary>
        /// Action fired when the game is paused.
        /// </summary>
        public event Action OnPaused;

        /// <summary>
        /// Action fired when the game is resumed.
        /// </summary>
        public event Action OnResumed;

        /// <summary>
        /// Whether is paused.
        /// </summary>
        [field: NonSerialized]
        public bool IsPaused { get; private set; }

        /// <summary>
        /// Toggles between <see cref="Pause"/> and <see cref="Resume"/>.
        /// </summary>
        public void Toggle()
        {
            if (IsPaused) Resume();
            else Pause();
        }

        /// <summary>
        /// Pauses the game.
        /// </summary>
        public void Pause()
        {
            OnPaused?.Invoke();

            IsPaused = true;
            if (StopTimeScale) Time.timeScale = 0f;
        }

        /// <summary>
        /// Resumes the game.
        /// </summary>
        public void Resume()
        {
            IsPaused = false;
            if (StopTimeScale)
            {
                Time.timeScale = 1f;
                // All Time properties will be updated only in the next frame.
                _ = AwaitableCoroutine.Run(WaitAndInvokeResume());
                return;
            }

            OnResumed?.Invoke();
        }

        private IEnumerator WaitAndInvokeResume()
        {
            // Time.deltaTime would be 0F if not waiting for the Fixed Update.
            yield return new WaitForFixedUpdate();
            OnResumed?.Invoke();
        }
    }
}