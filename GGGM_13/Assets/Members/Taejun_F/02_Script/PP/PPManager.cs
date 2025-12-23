using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PPManager : MonoBehaviour
{
    public static PPManager Instance { get; private set; }
    [SerializeField] private Volume globalVolume;
    private DepthOfField _depth;

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

        if (!globalVolume.profile.TryGet(out _depth))
        {
            Debug.LogWarning("Depth of field를 global volume에서 찾지못함");
        }
    }

    public void EnableBlur()
    {
        _depth.active = true;
    }

    public void DisableBlur()
    {
        _depth.active = false;
    }
}
