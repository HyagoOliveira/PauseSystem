using UnityEngine;

namespace ActionCode.PauseSystem
{
    /// <summary>
    /// Manager for the Pause System. It initializes the <see cref="PauseSettings"/>.
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class PauseManager : MonoBehaviour
    {
        [SerializeField, Tooltip("The Pause Settings asset reference.")]
        private PauseSettings settings;
    }
}