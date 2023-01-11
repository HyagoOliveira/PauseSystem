using UnityEngine;
using System.Collections.Generic;

namespace ActionCode.PauseSystem
{
    /// <summary>
    /// Settings class for the Pause System. Use it to subscribe <see cref="IPauseable"/> instances.
    /// </summary>
    [CreateAssetMenu(fileName = "PauseSettings", menuName = "ActionCode/Pause Manager/Settings", order = 110)]
    public sealed class PauseSettings : ScriptableObject, IPauseable
    {
        [SerializeField, Tooltip("Whether to stop the TimeScale when pause.")]
        private bool stopTimeScale = true;
        
        public bool IsPaused { get; private set; }
        
        private readonly List<IPauseable> pauseables = new();

        internal void Initialize ()
        {
            IsPaused = false;
            pauseables.Clear();
        }

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
            foreach (var pauseable in pauseables)
            {
                pauseable.Pause();
            }

            IsPaused = true;
            if (stopTimeScale) Time.timeScale = 0f;
        }

        public void Resume()
        {
            IsPaused = false;
            if (stopTimeScale) Time.timeScale = 1f;

            foreach (var pauseable in pauseables)
            {
                pauseable.Resume();
            }
        }

        /// <summary>
        /// Registers the given paused instance to be paused when <see cref="Pause"/> is called.
        /// </summary>
        /// <param name="pauseable">The pauseable instance.</param>
        public void Register(IPauseable pauseable)
        {
            var canAdd = !pauseables.Contains(pauseable);
            if (canAdd) pauseables.Add(pauseable);
        }

        /// <summary>
        /// Unregisters the given paused instance.
        /// </summary>
        /// <param name="pauseable">The pauseable instance.</param>
        public void Unregister(IPauseable pauseable)
        {
            var canRemove = pauseables.Contains(pauseable);
            if (canRemove) pauseables.Remove(pauseable);
        }
    }
}