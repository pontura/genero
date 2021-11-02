using UnityEngine;

public class AudioSpectrum : MonoBehaviour
{
    AudioSource audioSource;
    public bool isOn;
    public float result;

    public void Start()
    {
        audioSource = Data.Instance.GetComponent<AudioManager>().GetAudioSource("voices");
        isOn = true;
    }
    public void SetOff()
    {
        isOn = false;
        result = 0;
    }
    public void SetAudioSource(AudioSource au)
    {
        audioSource = au;
    }
    void Update()
    {
        if(audioSource == null)
            audioSource = Data.Instance.GetComponent<AudioManager>().GetAudioSource("voices");

        if (!isOn || audioSource == null || !audioSource.isPlaying)
        {
            result = 0;
            return;
        }
        float[] spectrum = new float[256];

        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        int frag = (int)(spectrum.Length / 4);
        result = spectrum[(frag * 0)] + spectrum[(frag * 0) + 1] + spectrum[(frag * 0) + 2];

    }
}