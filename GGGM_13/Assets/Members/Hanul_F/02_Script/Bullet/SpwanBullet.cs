using System.Collections.Generic;
using UnityEngine;

public class SpwanBullet : MonoBehaviour
{
    public static SpwanBullet Instance { get; private set; }

    [SerializeField] private List<BulletTrajectoryDataSO> bulletTrajectoryDataSOs = new List<BulletTrajectoryDataSO>();

    [SerializeField] private GameObject BulletPreFab;
    [SerializeField] private GameObject center;
    private float addSpeed = 0f;

    public float AddSpeed
    {
        get
        {
            return addSpeed;
        }

        set
        {
            addSpeed += value;
            addSpeed = Mathf.Clamp(addSpeed,0,100f);
        }
    } 

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }


    public void Ctrate(Transform firePos)
    {
        BulletTrajectoryDataSO ran = bulletTrajectoryDataSOs[Random.Range(0,bulletTrajectoryDataSOs.Count)];
        IBullet bullet = Instantiate(BulletPreFab, firePos.position,firePos.rotation , gameObject.transform).GetComponent<IBullet>();
        bullet.SetCenter(center);
        bullet.SetSpeed(ran.MinSpeed,ran.bulletSpeed + addSpeed,ran);
    }
}
