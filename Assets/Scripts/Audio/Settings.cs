using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public static Settings Instance;

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider bgmSlider;

    private void Start()
    {
        if (Settings.Instance is null)
        {
            return;
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        float bgmDB;

        audioMixer.GetFloat("bgmVol", out bgmDB);

        bgmSlider.value = GetFloatVolume(bgmDB);
    }

    private float GetFloatVolume(float value)
    {
        return Mathf.Pow(10, value / 20);
    }

    private float GetDb(float value)
    {
        return Mathf.Log10(value) * 20;
    }

    public void SetBGM(float value)
    {
        audioMixer.SetFloat("bgmVol", GetDb(value));
    }
}
