using UnityEngine;
using System.Collections.Generic;

namespace ActionCode.PauseSystem
{
    /// <summary>
    /// Settings class for the Pause System. Use it to subscribe <see cref="IPauseable"/> instances.
    /// </summary>
    [CreateAssetMenu(fileName = "PauseSettings", menuName = "ActionCode/Pause Settings", order = 110)]
    public sealed class PauseSettings : ScriptableObject, IPauseable
    {
        private readonly List<IPauseable> pauseables = new();

        internal void Initialize () => pauseables.Clear();
        
        public void Pause()
        {
            foreach (var pauseable in pauseables)
            {
                pauseable.Pause();
            }
        }

        public void Resume()
        {
            foreach (var pauseable in pauseables)
            {
                pauseable.Resume();
            }
        }

        public void Register(IPauseable pauseable)
        {
            var canAdd = !pauseables.Contains(pauseable);
            if (canAdd) pauseables.Add(pauseable);
        }

        public void Unregister(IPauseable pauseable)
        {
            var canRemove = pauseables.Contains(pauseable);
            if (canRemove) pauseables.Remove(pauseable);
        }
    }
}