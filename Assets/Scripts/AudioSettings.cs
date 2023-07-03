using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public AudioMixer mixer;

    public Image Music;
    public Image SFX;
    private void Start()
    {
        GameObject.Find("GameMaster").GetComponent<PlayerStats>().LoadPlayer();
        if (PlayerStats.MusicMuted)
        {
            mixer.SetFloat("MusicVolume", -80f);
            Music.color = Color.red;
        }
        else
        {
            mixer.SetFloat("MusicVolume", 0f);
            Music.color = Color.white;
        }
        if (PlayerStats.SFXMuted)
        {
            mixer.SetFloat("SFXVolume", -80f);
            SFX.color = Color.red;
        }
        else
        {
            mixer.SetFloat("SFXVolume", 0f);
            SFX.color = Color.white;
        }
    }
    public void SetMusicB()
    {
        if (!PlayerStats.MusicMuted)
        {
            mixer.SetFloat("MusicVolume", -80f);
            Music.color = Color.red;
            PlayerStats.MusicMuted = true;
        }
        else
        {
            mixer.SetFloat("MusicVolume", 0f);
            Music.color = Color.white;
            PlayerStats.MusicMuted = false;
        }
        GameObject.Find("GameMaster").GetComponent<PlayerStats>().SavePlayer();
    }
    public void SetSFXB()
    {
        if (!PlayerStats.SFXMuted)
        {
            mixer.SetFloat("SFXVolume", -80f);
            SFX.color = Color.red;
            PlayerStats.SFXMuted = true;
        }
        else
        {
            mixer.SetFloat("SFXVolume", 0f);
            SFX.color = Color.white;
            PlayerStats.SFXMuted = false;
        }
        GameObject.Find("GameMaster").GetComponent<PlayerStats>().SavePlayer();
    }
}
