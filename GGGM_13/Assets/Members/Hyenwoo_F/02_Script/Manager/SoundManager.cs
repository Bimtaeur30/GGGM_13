using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicManager;
    [SerializeField] private AudioSource sfxManager;
    [SerializeField] private List<AudioClip> audioClipList;
    private Dictionary<SFX, AudioClip> soundClipDictionary;
    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        int i = 0;
        foreach (SFX item in Enum.GetValues(typeof(SFX)))
        {
            soundClipDictionary[item] = audioClipList[i];
            i++;
        }
    }

    public void PlaySound(SFX sfx)
    {
        sfxManager.PlayOneShot(soundClipDictionary[sfx]);
    }
}

public enum SFX
{ }

