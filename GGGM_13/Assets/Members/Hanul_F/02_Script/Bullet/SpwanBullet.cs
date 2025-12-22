using System.Collections.Generic;
using UnityEngine;

public class SpwanBullet : MonoBehaviour
{
    public static SpwanBullet Instance { get; private set; }

    [SerializeField] private GameObject BulletPreFab;
    [SerializeField] private GameObject center;
    private List<IBullet> bulletList;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        bulletList = new List<IBullet>();
    }

    public void Ctrate(Vector3 firePos)
    {
        IBullet bullet = Instantiate(BulletPreFab, firePos, Quaternion.identity, gameObject.transform).GetComponent<IBullet>();
        bullet.SetCenter(center);
        bulletList.Add(bullet);
    }
}
