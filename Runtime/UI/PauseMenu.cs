using UnityEngine;
using ActionCode.PauseSystem.EventSystem;

namespace ActionCode.PauseSystem.UI
{
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(PauseListener))]
    public class PauseMenu : MonoBehaviour, IPauseable
    {
        [SerializeField, Tooltip("Local Canvas component.")]
        protected Canvas canvas;
        [SerializeField, Tooltip("Local Pause Listener component.")]
        protected PauseListener listener;
        [SerializeField, Tooltip("Local Audio Source component.")]
        protected AudioSource audioSource;

        public bool Visible
        {
            get => canvas.enabled;
            set => canvas.enabled = value;
        }

        protected virtual void Reset()
        {
            canvas = GetComponent<Canvas>();
            listener = GetComponent<PauseListener>();
            audioSource = GetComponent<AudioSource>();
        }

        public virtual void Toggle()
        {
            if (Visible) Resume();
            else Pause();
        }

        public virtual void Pause()
        {
            Show();
            listener.Pause();
            StopTimeScale();
        }

        public virtual void Resume()
        {
            Hide();
            NormalizeTimeScale();
            listener.Resume();
        }

        public virtual void Show()
        {
            Visible = true;
        }

        public virtual void Hide()
        {
            Visible = false;
        }

        public virtual void StopTimeScale()
        {
            Time.timeScale = 0F;
        }

        public virtual void NormalizeTimeScale()
        {
            Time.timeScale = 1F;
        }

        public virtual void PlayAudioSource()
        {
            audioSource.Play();
        }

        public virtual void PlayAudioSource(AudioClip clip)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}