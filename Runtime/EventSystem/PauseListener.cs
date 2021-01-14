using UnityEngine;
using System.Collections.Generic;

namespace ActionCode.PauseSystem.EventSystem
{
    public sealed class PauseListener : MonoBehaviour, IPauseable
    {
        private readonly List<IPauseable> pauseables = new List<IPauseable>();

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

        public static bool Find(out PauseListener pauseSystem)
        {
            pauseSystem = FindObjectOfType<PauseListener>();
            return pauseSystem != null;
        }
    }
}