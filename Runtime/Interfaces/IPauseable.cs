namespace ActionCode.PauseSystem
{
    /// <summary>
    /// Interface used on objects able to Pause and Resume.
    /// </summary>
    public interface IPauseable : IResumable
    {
        /// <summary>
        /// Pauses the instance.
        /// </summary>
        void Pause();
    }
}