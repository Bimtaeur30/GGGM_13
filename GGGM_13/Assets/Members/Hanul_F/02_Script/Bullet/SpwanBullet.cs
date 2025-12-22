using UnityEngine;
using UnityEngine.InputSystem;

public class SpwanBullet : MonoBehaviour
{

    [SerializeField] private GameObject bulletPreFab = null;
    [SerializeField] private Transform firePos = null;
    [SerializeField] private GameObject cneter = null;
    void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            GameObject bullet =  Instantiate(bulletPreFab, firePos.position, Quaternion.identity);
            bullet.GetComponent<BulletTrajectory>().CenterSet(cneter);
        }
    }
}
