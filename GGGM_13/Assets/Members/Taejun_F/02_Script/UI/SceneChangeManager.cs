using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public static SceneChangeManager Instance { get; private set; }
    [SerializeField] private StripPatternUI _sceneChangePref;

    private bool _isSceneChanged = false;
    private bool _isSceneChanging = false;

    private StripPatternUI _spawnedUI;
    private RectTransform _canvasRT;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        //=======================================//

        _canvasRT = gameObject.transform.GetChild(0).GetComponent<RectTransform>();
        _spawnedUI = Instantiate(_sceneChangePref, _canvasRT.gameObject.transform);


        _spawnedUI.SetStickSize(_canvasRT.rect.width, _canvasRT.rect.height);
        if (_isSceneChanged == true)
        {
            _spawnedUI.OpenEffect();
            _isSceneChanged = false;
        }
    }

   

    //private void Start()
    //{
    //    MoveScene(1);
    //}

    private void OnEnable()
    {
        SceneManager.sceneLoaded += HandleSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= HandleSceneLoaded;
    }
    
    private void HandleSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        OnSceneLoaded();
    }

    private void OnSceneLoaded()
    {
        if (_isSceneChanged == true)
        {
            _spawnedUI.OpenEffect();
            _isSceneChanged = false;
        }
    }

    public void MoveScene(int _sceneIdx)
    {
        if (_isSceneChanged == true) return; // 씬 이동중이면 뒤로가기
        if (SceneManager.sceneCount < _sceneIdx)
        {
            Debug.LogError("입력하신 씬 인덱스가 잘못되었습니다. 확인바랍니다.");
            return;
        }
        _isSceneChanging = true;
        _spawnedUI.SetStickSize(_canvasRT.rect.width, _canvasRT.rect.height);

        Action corComplete;
        corComplete = () =>
        {
            SceneManager.LoadScene(_sceneIdx);
            _isSceneChanging = false;
        };
        StartCoroutine(_spawnedUI.CorCloseEffect(corComplete));
        _isSceneChanged = true;
    }
}
