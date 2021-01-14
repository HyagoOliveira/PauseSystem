namespace ActionCode.PauseSystem
{
    /// <summary>
    /// Interface used on objects able to Pause and Resume.
    /// </summary>
    public interface IPauseable
    {
        /// <summary>
        /// Pauses the instance.
        /// </summary>
        void Pause();

        /// <summary>
        /// Resumes the instance.
        /// </summary>
        void Resume();
    }
}