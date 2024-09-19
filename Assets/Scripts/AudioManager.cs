using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioSource music;
    public AudioSource sfx;

    [Header("Refs")]
    public Slider musicSlider;
    public Slider sfxSlider;

    [Header("Background Music")]
    [SerializeField] private AudioClip background;

    [Header("SFX")]
    [SerializeField] private AudioClip shoot;
    [SerializeField] private AudioClip deathExplosion;
    [SerializeField] private AudioClip bonusShip;
    [SerializeField] private AudioClip killInvader;

    [Range(0f, 1f)]
    public float musicVolume = 0.35f;
    [Range(0f, 1f)]
    public float sfxVolume = 0.5f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        music.clip = background;
        music.loop = true;
        music.Play();

        LoadVolumeSettings(); 
    }

    private void Update()
    {
        SetMusicVolume(musicSlider.value);
        SetSFXVolume(sfxSlider.value);
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        music.volume = musicVolume;
        SaveVolumeSettings();
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        sfx.volume = sfxVolume;
        SaveVolumeSettings(); 
    }

    public void Shoot()
    {
        sfx.PlayOneShot(shoot, sfxVolume);
    }

    public void DeathExplosion()
    {
        sfx.PlayOneShot(deathExplosion, sfxVolume);
    }

    public void BonusShip()
    {
        sfx.PlayOneShot(bonusShip, sfxVolume);
    }

    public void KillInvader()
    {
        sfx.PlayOneShot(killInvader, sfxVolume);
    }

    private void LoadVolumeSettings()
    {
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.35f);
        sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 0.5f);

        musicSlider.value = musicVolume;
        sfxSlider.value = sfxVolume;

        music.volume = musicVolume; 
        sfx.volume = sfxVolume;     
    }

    private void SaveVolumeSettings()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
        PlayerPrefs.Save();
    }
}
