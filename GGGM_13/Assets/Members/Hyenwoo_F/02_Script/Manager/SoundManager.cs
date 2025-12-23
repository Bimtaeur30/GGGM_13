using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixer musicMixer;
    [SerializeField] private AudioSource musicManager;
    [SerializeField] private AudioMixer sfxMixer;
    [SerializeField] private AudioSource sfxManager;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private List<AudioClip> sfxList;
    [SerializeField] private List<AudioClip> bgmList;
    private Dictionary<SFX, AudioClip> sfxDictionary = new Dictionary<SFX, AudioClip>();
    private Dictionary<BGM, AudioClip> bgmDictionary = new Dictionary<BGM, AudioClip>();
    public RunSFX runSFX { get; private set; }
    private YHWPlayer player;
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

        runSFX = GetComponentInChildren<RunSFX>();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += ChoiceBGM;
    }

    private void Start()
    {
        player = YHWGameManager.Instance.Player.GetComponent<YHWPlayer>();
        player.HPCompo._onDie += () => musicManager.Stop();
        int i = 0;
        foreach (SFX item in Enum.GetValues(typeof(SFX)))
        {
            sfxDictionary[item] = sfxList[i];
            i++;
        }
        i = 0;
        foreach (BGM item in Enum.GetValues(typeof(BGM)))
        {
            bgmDictionary[item] = bgmList[i];
            i++;
        }
    }

    public void SetMusicVolume(float value)
    {
        musicMixer.SetFloat("Music", Mathf.Log10(value) * 20);
    }

    public void SetSfxVolume(float value)
    {
        sfxMixer.SetFloat("SFX", Mathf.Log10(value) * 20);
    }

    public void PlaySound(SFX sfx)
    {
        sfxManager.PlayOneShot(sfxDictionary[sfx]);
    }

    public void PlayBGM(BGM bgm)
    {
        musicManager.Stop();
        musicManager.clip = bgmDictionary[bgm];
        musicManager.Play();
    }

    void ChoiceBGM(Scene scene, LoadSceneMode mode)
    {
        int _scene = SceneManager.GetActiveScene().buildIndex;

        if (_scene == 0)
        {
            PlayBGM(BGM.StartBGM);
        }
        else
        {
            PlayBGM(BGM.GameBGM);
        }
    }
}

public enum SFX
{ 
    GameOver,
    PlayerHit,
    PlayerJump,
    PlayerLanding, 
    PlayerRun,
    JumpSloatCharge,
    GunFiring, 
    GunExplosion,
    CardUp,
    ButtonSelect,
    ButtonClick,
    MetalHit
}

public enum BGM
{
    StartBGM,
    GameBGM,
    //GameOverBGM
}

