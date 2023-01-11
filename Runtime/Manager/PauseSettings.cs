using System;
using UnityEngine;

namespace ActionCode.PauseSystem
{
    /// <summary>
    /// Settings class for the Pause System.
    /// Use it to subscribe to <see cref="OnPaused"/> and <see cref="OnResumed"/> events.
    /// </summary>
    [CreateAssetMenu(fileName = "PauseSettings", menuName = "ActionCode/Pause Manager/Settings", order = 110)]
    public sealed class PauseSettings : ScriptableObject
    {
        [SerializeField, Tooltip("Whether to stop the TimeScale when pause.")]
        private bool stopTimeScale = true;

        public event Action OnPaused;
        public event Action OnResumed;
        
        [field: NonSerialized]
        public bool IsPaused { get; private set; }
        
        /// <summary>
        /// Toggles between <see cref="Pause"/> and <see cref="Resume"/>.
        /// </summary>
        public void Toggle ()
        {
            if (IsPaused) Resume();
            else Pause();
        }
        
        public void Pause()
        {
            OnPaused?.Invoke();

            IsPaused = true;
            if (stopTimeScale) Time.timeScale = 0f;
        }

        public void Resume()
        {
            IsPaused = false;
            if (stopTimeScale) Time.timeScale = 1f;

            OnResumed?.Invoke();
        }
    }
}