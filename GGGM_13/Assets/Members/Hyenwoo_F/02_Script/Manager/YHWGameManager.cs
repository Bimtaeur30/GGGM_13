using UnityEngine;

public class YHWGameManager : MonoBehaviour
{
    [field:SerializeField] public GameObject Player { get; private set; }
    [field:SerializeField] public Camera MainCamera { get; private set; }
    public static YHWGameManager Instance { get; private set; }

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
}
