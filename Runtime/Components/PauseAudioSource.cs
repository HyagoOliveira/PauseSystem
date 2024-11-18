using UnityEngine;

namespace ActionCode.PauseSystem
{
    /// <summary>
    /// Pauses and resumes all AudioSource components.
    /// </summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(AudioSource))]
    public sealed class PauseAudioSource : MonoBehaviour
    {
        [SerializeField, Tooltip("The local AudioSource component. It will be paused/resumed.")]
        private AudioSource source;

        private void Reset() => source = GetComponent<AudioSource>();

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

        private void HandlePaused() => source.Pause();
        private void HandleResumed() => source.UnPause();
    }
}