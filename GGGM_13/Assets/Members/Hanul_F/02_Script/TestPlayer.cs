using UnityEngine;
using UnityEngine.InputSystem;

public class TestPlayer : MonoBehaviour
{
    [SerializeField] Transform firePos;
    void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            SpwanBullet.Instance.Ctrate(firePos);
        }
    }
}
