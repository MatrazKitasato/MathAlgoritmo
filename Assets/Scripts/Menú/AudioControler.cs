using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Unity.UI;

public class AudioControler : MonoBehaviour
{

    public static AudioControler instance;
    public AudioSource audioSourceMusic;
    public AudioSource audioSourceSFX;
    public AudioMixer mixer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    void Start()
    {
        CargarVolumen();
    }
    private void CargarVolumen()
    {
        float volumenMusica = PlayerPrefs.GetFloat("VolumenMusica", 1f);
        float volumenSFX = PlayerPrefs.GetFloat("VolumenSFX", 1f);
        mixer.SetFloat("VolumenMusica", Mathf.Log10(volumenMusica) * 20);
        mixer.SetFloat("VolumenSFX", Mathf.Log10(volumenSFX) * 20);
    }
}

