using UnityEngine;

namespace ActionCode.PauseSystem
{
    /// <summary>
    /// Pauses and resumes all AudioSource components.
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class PauseAudioSources : MonoBehaviour
    {
        [SerializeField, Tooltip("The local AudioSource components. They will be paused/resumed.")]
        private AudioSource[] sources;

        private void Reset() =>
            sources = GetComponentsInChildren<AudioSource>(includeInactive: true);

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

        private void HandlePaused()
        {
            foreach (var source in sources)
            {
                source.Pause();
            }
        }

        private void HandleResumed()
        {
            foreach (var source in sources)
            {
                source.UnPause();
            }
        }
    }
}