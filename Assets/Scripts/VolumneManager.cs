using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;

    void Start()
    {
        float volume = PlayerPrefs.GetFloat("Master", 0.75f);
        volumeSlider.value = volume;
        SetVolume(volume);
    }

    public void SetVolume(float value)
    {
        float dB = Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20f;
        audioMixer.SetFloat("Master", dB);
        PlayerPrefs.SetFloat("Master", value);
    }
}