using System.Collections.Generic;
using UnityEngine;

public class SpwanBullet : MonoBehaviour
{
    public static SpwanBullet Instance { get; private set; }

    [SerializeField] private GameObject BulletPreFab;
    [SerializeField] private GameObject center;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }


    public void Ctrate(Vector3 firePos)
    {
        IBullet bullet = Instantiate(BulletPreFab, firePos, Quaternion.identity, gameObject.transform).GetComponent<IBullet>();
        bullet.SetCenter(center);
    }

    void Update()
    {
        Debug.Log(Instance);
    }
}
