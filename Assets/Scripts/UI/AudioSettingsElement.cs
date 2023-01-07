using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Audio;

public class AudioSettingsElement : VisualElement
{
    public new class UxmlFactory : UxmlFactory<AudioSettingsElement, UxmlTraits> {}

    private Slider sliderMasterVolume;
    private Slider sliderMusicVolume;
    private Slider sliderSoundsVolume;

    private const string MASTERVOLUME = "MasterVolume";
    private const string MUSICVOLUME = "MusicVolume";
    private const string SOUNDSVOLUME = "SoundsVolume";

    public AudioSettingsElement()
    {
        VisualTreeAsset visualTree = Resources.Load<VisualTreeAsset>("UI/Templates/AudioSettingsTemplate");
        visualTree.CloneTree(this);

        sliderMasterVolume = this.Q<Slider>("SliderMasterVolume");
        sliderMusicVolume = this.Q<Slider>("SliderMusicVolume");
        sliderSoundsVolume = this.Q<Slider>("SliderSoundsVolume");

        AudioMixer audioMixer = Resources.Load<AudioMixer>("Audio/MainMixer");

        /*
            https://johnleonardfrench.com/the-right-way-to-make-a-volume-slider-in-unity-using-logarithmic-conversion/             
        */
        sliderMasterVolume.RegisterValueChangedCallback(evt =>
        {
            audioMixer.SetFloat(MASTERVOLUME, Mathf.Log10(evt.newValue) * 20);
        });
        sliderMusicVolume.RegisterValueChangedCallback(evt =>
        {
            audioMixer.SetFloat(MUSICVOLUME, Mathf.Log10(evt.newValue) * 20);
        });
        sliderSoundsVolume.RegisterValueChangedCallback(evt =>
        {
            audioMixer.SetFloat(SOUNDSVOLUME, Mathf.Log10(evt.newValue) * 20);
        });
    }
}
