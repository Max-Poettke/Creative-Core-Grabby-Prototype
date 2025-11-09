using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    
    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }

    public void SetAmbientVolume(float volume)
    {
        audioMixer.SetFloat("AmbientVolume", Mathf.Log10(volume) * 20);
    }
}
