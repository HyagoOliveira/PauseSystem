using System;

namespace ActionCode.PauseSystem
{
    /// <summary>
    /// Settings interface for the Pause System.
    /// </summary>
    public interface IPauseSettings 
    {
        /// <summary>
        /// Action fired when the game is paused.
        /// </summary>
        event Action OnPaused;
        
        /// <summary>
        /// Action fired when the game is resumed.
        /// </summary>
        event Action OnResumed;
        
        /// <summary>
        /// Whether is paused.
        /// </summary>
        bool IsPaused { get; }
        
        /// <summary>
        /// Whether to stop the TimeScale when paused.
        /// </summary>
        bool StopTimeScale { get; }

        /// <summary>
        /// Toggles between <see cref="Pause"/> and <see cref="Resume"/>.
        /// </summary>
        void Toggle ();

        /// <summary>
        /// Pauses the game.
        /// </summary>
        void Pause();
        
        /// <summary>
        /// Resumes the game.
        /// </summary>
        void Resume();
    }
}