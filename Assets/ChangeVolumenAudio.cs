using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ChangeVolumenAudio : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider sliderMusica;
    public Slider sliderSFX;
    private void Awake()
    {
        sliderMusica.onValueChanged.AddListener(CambiarVolumenMusica);
        sliderSFX.onValueChanged.AddListener(CambiarSFX);
    }
    void Start()
    {
        CambiarVolumenMusica(sliderMusica.value);
        CambiarVolumenMusica(sliderSFX.value);
    }
    void Update()
    {

    }
    public void CambiarVolumenMusica(float valor)
    {
        audioMixer.SetFloat("VolumenMusica", Mathf.Log10(valor) * 20);
    }
    public void CambiarSFX(float valor)
    {
        audioMixer.SetFloat("VolumenSFX", Mathf.Log10(valor) * 20);
    }
    public void OnDisable()
    {
        PlayerPrefs.SetFloat("VolumenMusica", sliderMusica.value);
        PlayerPrefs.SetFloat("VolumenSFX", sliderSFX.value);
    }
}