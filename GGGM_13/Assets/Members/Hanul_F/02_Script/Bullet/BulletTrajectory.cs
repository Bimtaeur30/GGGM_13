using System;
using UnityEngine;

public class BulletTrajectory : MonoBehaviour
{
    public BulletTrajectoryDataSO BulletTrajectoryData = null;

    public GameObject Center = null;
    [SerializeField]private float bulletSpeed;
    private float bulletMaxSpeed;
    private float decrease;
    private float bulletWiatTiem;
    private float radius;
    private float maxCircleMove;
    private float rotated = 0f;
    private float angle;

    void Awake()
    {
        bulletMaxSpeed = BulletTrajectoryData.bulletSpeed;
        bulletSpeed = bulletMaxSpeed;
        bulletWiatTiem = BulletTrajectoryData.bulletWiatTiem;
        radius = BulletTrajectoryData.radius;
        decrease = BulletTrajectoryData.Decrease;
        maxCircleMove = Mathf.PI * 2f * BulletTrajectoryData.CircleMoveAngle;
    }


    void Start()
    {
        Vector2 dir = (Vector2)transform.position - (Vector2)Center.transform.position;
        angle = Mathf.Atan2(dir.y, dir.x);
    }

    void Update()
    {
        if (rotated <= maxCircleMove)
        {
            CircleMove();
        }
    }

    private void CircleMove()
    {
        float rotat = bulletSpeed * Time.deltaTime;
        angle -= rotat;
        rotated += rotat;

        float x = Center.transform.position.x + Mathf.Cos(angle) * radius;
        float y = Center.transform.position.y + Mathf.Sin(angle) * radius;

        transform.position = new Vector2(x, y);
        SlowSpeed();
    }

    private void SlowSpeed()
    {
        bulletSpeed -= Time.deltaTime * decrease;
        bulletSpeed = Mathf.Clamp(bulletSpeed,0.5f,bulletMaxSpeed);
    }

    public void CenterSet(GameObject center)
    {
        this.Center = center;
    }
}
