using System;

namespace ActionCode.PauseSystem
{
    /// <summary>
    /// Settings interface for the Pause System.
    /// </summary>
    public interface IPauseSettings
    {

        event Action OnPaused;


        event Action OnResumed;


        bool IsPaused { get; }


        bool StopTimeScale { get; }


        void Toggle();


        void Pause();


        void Resume();
    }
}