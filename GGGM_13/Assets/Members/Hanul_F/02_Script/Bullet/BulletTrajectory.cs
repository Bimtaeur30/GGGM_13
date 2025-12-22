using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public enum state
{
    Circle,
    straight
}

public class BulletTrajectory : MonoBehaviour, IBullet
{
    public BulletTrajectoryDataSO BulletTrajectoryData = null;

    public GameObject Center = null;
    [SerializeField] private float bulletSpeed;
    private float bulletMaxSpeed;
    private float decrease;
    private float radius;
    private float maxCircleMove;
    private float rotated = 0f;
    private float angle;

    private float lerpTime = 1f;

    private state nowState;

    private Vector3 straightMove;

    void Awake()
    {
        bulletMaxSpeed = BulletTrajectoryData.bulletSpeed;
        bulletSpeed = bulletMaxSpeed;
        radius = BulletTrajectoryData.radius;
        decrease = BulletTrajectoryData.Decrease;
        maxCircleMove = Mathf.PI * 2f;
        nowState = state.Circle;

    }


    void Update()
    {
        switch (nowState)
        {
            case state.Circle:
                if (rotated <= maxCircleMove)
                {
                    CircleMove();
                }
                else
                {
                    StartStraight();
                    nowState = state.straight;
                    bulletSpeed = bulletMaxSpeed;
                    StartCoroutine(DeathCoroutine());
                }
                break;
            case state.straight:
                StraightMoving();
                break;
        }
    }
    private void StartStraight()
    {
        straightMove =
        new Vector3
        (
        Mathf.Sin(angle),
        -Mathf.Cos(angle),

        transform.position.z
        );
    }

    private void StraightMoving()
    {
        transform.position += straightMove * bulletSpeed * Time.deltaTime;
    }

    private IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }


    private void CircleMove()
    {
        float rotat = bulletSpeed * Time.deltaTime;
        angle -= rotat;
        rotated += rotat;

        float x = Center.transform.position.x + Mathf.Cos(angle) * radius;
        float y = Center.transform.position.y + Mathf.Sin(angle) * radius;

        Vector2 nextPos = new Vector2(x, y);
        transform.position = Vector2.Lerp(transform.position, nextPos, lerpTime * Time.deltaTime);
        SlowSpeed();
    }

    private void SlowSpeed()
    {
        bulletSpeed -= Time.deltaTime * decrease;
        bulletSpeed = Mathf.Clamp(bulletSpeed, 0.5f, bulletMaxSpeed);
    }

    public void SetCenter(GameObject center)
    {
        this.Center = center;
        Vector2 dir = (Vector2)transform.position - (Vector2)Center.transform.position;
        angle = Mathf.Atan2(dir.y, dir.x);
    }
}
