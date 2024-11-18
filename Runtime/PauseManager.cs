using System;
using UnityEngine;
using System.Collections;
using ActionCode.AwaitableCoroutines;

namespace ActionCode.PauseSystem
{
    /// <summary>
    /// Pause Manager. Use it to subscribe to <see cref="OnPaused"/> and <see cref="OnResumed"/> events.
    /// </summary>
    public static class PauseManager
    {
        /// <summary>
        /// Action fired when the game is paused.
        /// </summary>
        public static event Action OnPaused;

        /// <summary>
        /// Action fired when the game is resumed.
        /// </summary>
        public static event Action OnResumed;

        /// <summary>
        /// Whether is paused.
        /// </summary>
        public static bool IsPaused { get; private set; }

        /// <summary>
        /// Whether to stop the TimeScale when paused.
        /// </summary>
        public static bool StopTimeScale { get; set; } = true;

        /// <summary>
        /// Toggles between <see cref="Pause"/> and <see cref="Resume"/>.
        /// </summary>
        public static void Toggle()
        {
            if (IsPaused) Resume();
            else Pause();
        }

        /// <summary>
        /// Pauses the game.
        /// </summary>
        public static void Pause()
        {
            OnPaused?.Invoke();

            IsPaused = true;
            if (StopTimeScale) Time.timeScale = 0f;
        }

        /// <summary>
        /// Resumes the game.
        /// </summary>
        public static void Resume()
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

        private static IEnumerator WaitAndInvokeResume()
        {
            // Time.deltaTime would be 0F if not waiting for the Fixed Update.
            yield return new WaitForFixedUpdate();
            OnResumed?.Invoke();
        }
    }
}