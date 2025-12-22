using System.Collections;
using UnityEngine;

public enum state
{
    Start,
    Circle,
    straight
}

public class BulletTrajectory : MonoBehaviour, IBullet
{
    public BulletTrajectoryDataSO BulletTrajectoryData = null;

    
    public GameObject Center = null;
    
    [SerializeField] private float lerpFollow = 12f;
    [SerializeField] private float bulletSpeed;
    private float bulletMaxSpeed;
    private float decrease;
    private float radius;
    private float maxCircleMove;
    private float rotated = 0f;
    private float angle;

    private float minSpeed;

    private float lerpTime = 3f;
    private float firstLerpTiem = 0.2f;

    private float timer = 0f;

    private state nowState;

    private Vector3 straightMove;



    void Update()
    {
        switch (nowState)
        {
            case state.Start:
                FristCircleMove();
                timer += Time.deltaTime;
                if (timer >= firstLerpTiem)
                {
                    nowState = state.Circle;
                }
                break;

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
        new Vector2
        (
        Mathf.Sin(angle),
        -Mathf.Cos(angle)
        );
    }

    private void StraightMoving()
    {
        transform.position += transform.right * bulletSpeed;
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
        float t = 1f - Mathf.Exp(-lerpFollow * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, (Vector3)nextPos, t);
        SlowSpeed();
        LookTangent();
    }

    private void FristCircleMove()
    {
        float rotat = bulletSpeed * Time.deltaTime;
        angle -= rotat;
        rotated += rotat;

        float x = Center.transform.position.x + Mathf.Cos(angle) * radius;
        float y = Center.transform.position.y + Mathf.Sin(angle) * radius;

        Vector2 nextPos = new Vector2(x, y);

        float t = Mathf.Clamp01(lerpTime * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, (Vector3)nextPos, t);
        SlowSpeed();
        LookTangent();
    }


    private void SlowSpeed()
    {
        bulletSpeed -= Time.deltaTime * decrease;
        bulletSpeed = Mathf.Clamp(bulletSpeed, minSpeed, bulletMaxSpeed);
    }

    public void SetCenter(GameObject center)
    {
        this.Center = center;
        Vector2 dir = (Vector2)transform.position - (Vector2)Center.transform.position;
        radius = dir.magnitude;
        angle = Mathf.Atan2(dir.y, dir.x);
    }

    private void LookTangent()
    {
        Vector2 tangent = new Vector2(
            Mathf.Sin(angle),
            -Mathf.Cos(angle)
        );

        float rotZ = Mathf.Atan2(tangent.y, tangent.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    public void SetSpeed(float min, float max, BulletTrajectoryDataSO data)
    {
        BulletTrajectoryData = data;
        radius = BulletTrajectoryData.radius;
        decrease = BulletTrajectoryData.Decrease;
        maxCircleMove = Mathf.PI * 2f* BulletTrajectoryData.CircleMoveAngle;
        nowState = state.Start;
        minSpeed = min;
        bulletMaxSpeed = max;
        bulletSpeed = bulletMaxSpeed;
    }
}
