using System;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private float basicTime;
    [SerializeField] private float multipleTime;
    public static StageManager Instance { get; private set; }
    public int CurrentStage { get; private set; }
    public int BestStage { get; private set; }
    private float currentNextTime;
    private float timer = 0;

    private float addMax = 0.5f;
    private float addmin = 0.3f;
    private float adddecrase = 0.1f;

    //추가되는 최고 속도
    public float AddMax => addMax;
    
    //추가되는 최소 속도

    public float AddMin => addmin;

    // 추가되는 감소치
    public float AddDecrase => adddecrase;

    public event Action<int> _onNextStage;
    public event Action<int> _onChangeBestStage;
    private YHWPlayer player;

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
        player = YHWGameManager.Instance.Player.GetComponent<YHWPlayer>();
        CurrentStage = 1;
        BestStage = PlayerPrefs.GetInt("BestStage", 0);
        currentNextTime = basicTime;
        _onNextStage?.Invoke(CurrentStage);
    }

    private void Update()
    {
        if (!player.AnimCompo.AnimCompo.GetBool("IsDie"))
            timer += Time.deltaTime;

        if (timer >= currentNextTime)
        {
            NextStage();
        }
    }

    private void NextStage()
    {
        CurrentStage++;
        SpwanBullet.Instance.AddSpeed(addMax,addmin,adddecrase);
        if (BestStage < CurrentStage)
        {
            BestStage = CurrentStage;
            PlayerPrefs.SetInt("BestStage", CurrentStage);
            _onChangeBestStage?.Invoke(BestStage);
        }
        currentNextTime += multipleTime;
        _onNextStage?.Invoke(CurrentStage);
        timer = 0;
    }
}
