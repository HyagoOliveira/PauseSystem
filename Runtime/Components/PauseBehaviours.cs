using UnityEngine;

namespace ActionCode.PauseSystem
{
    /// <summary>
    /// Pauses and resumes all Behaviour components.
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class PauseBehaviours : MonoBehaviour
    {
        [SerializeField, Tooltip("All local Behaviour components. They will be paused/resumed.")]
        private Behaviour[] behaviours;

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

        private void HandlePaused() => SetBehavioursEnabled(false);
        private void HandleResumed() => SetBehavioursEnabled(true);

        private void SetBehavioursEnabled(bool enabled)
        {
            foreach (var behaviour in behaviours)
            {
                behaviour.enabled = enabled;
            }
        }
    }
}