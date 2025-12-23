using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpwanBullet : MonoBehaviour
{
    public static SpwanBullet Instance { get; private set; }

    [SerializeField] private List<BulletTrajectoryDataSO> bulletTrajectoryDataSOs = new List<BulletTrajectoryDataSO>();

    [SerializeField] private GameObject BulletPreFab;
    [SerializeField] private GameObject center;
    private float addMaxSpeed = 0f;
    private float addminSpeed = 0f;
    private float adddecrase = 0f;

    /// <summary>
    /// AddSpeed 함수는 SO에 있는 데이터 대신하여 작동하는 것이 아닌 SO + 지금 까지의 AddSpeed한 값을 정산하여 추가하는 값입니다.
    /// 예 AddSpeed(1,2,3), AddSpeed(1,2,3) 총 값은 2,4,6입니다. 
    /// </summary>
    /// <param name="추가할 최대속도값"></param>
    /// <param name="추가할 최소속도값"></param>
    /// <param name="추가할 감소값"></param>
    public void AddSpeed(float addMaxSpeed, float addminSpeed, float adddecrase)
    {
        this.adddecrase += adddecrase;
        this.addMaxSpeed += addMaxSpeed;
        this.addminSpeed += addminSpeed;
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
        float min = Mathf.Clamp(ran.MinSpeed + addminSpeed,ran.MinSpeed,6f);
        float max = Mathf.Clamp(ran.bulletSpeed + addMaxSpeed,ran.bulletSpeed,8f);
        float decrease = Mathf.Clamp(ran.Decrease +  adddecrase,ran.Decrease,3.5f);

        bullet.SetCenter(center);
        bullet.SetSpeed(min,max,decrease,ran);
    }
}
