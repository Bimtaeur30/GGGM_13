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
    [SerializeField] private float radiusAdjustSpeed = 5f;
    
    private float bulletMaxSpeed;
    private float decrease;
    private float radius;
    private float maxCircleMove;
    private float rotated = 0f;
    private float angle;

    private float minSpeed;



    private state nowState;

    private Vector3 straightMove;

    private float targetRadius;

    void Update()
    {
        switch (nowState)
        {
            // case state.Start:
            //     // FristCircleMove();
            //     timer += Time.deltaTime;
            //     StartMove();
            //     if (timer >= firstLerpTiem)
            //     {
            //         timer = 0f;

            //         Vector2 dir = (Vector2)transform.position - (Vector2)Center.transform.position;
            //         if (dir.sqrMagnitude < 0.000001f) dir = Vector2.right;

            //         angle = Mathf.Atan2(dir.y, dir.x);

            //         radius = dir.magnitude;
            //         rotated = 0f;

            //         nowState = state.Circle;
            //     }
            //     break;

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

    private void StartMove()
    {
        transform.position += new Vector3(0.2f,-0.2f).normalized* bulletSpeed * Time.deltaTime;
        SlowSpeed();
        LookTangent();
    }

    private void StraightMoving()
    {
        transform.position += transform.right * (bulletSpeed * radius) * Time.deltaTime;
    }

    private IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }


    private void CircleMove()
    {
        // float rotat = bulletSpeed * Time.deltaTime;
        // angle -= rotat;
        // rotated += rotat;

        // float x = Center.transform.position.x + Mathf.Cos(angle) * radius;
        // float y = Center.transform.position.y + Mathf.Sin(angle) * radius;

        // Vector2 nextPos = new Vector2(x, y);
        // float t = 1f - Mathf.Clamp01(-lerpFollow * Time.deltaTime);
        // transform.position = Vector3.Lerp(transform.position, (Vector3)nextPos, t);
        // SlowSpeed();
        // LookTangent();
        float rotat = bulletSpeed * Time.deltaTime;
        angle -= rotat;
        rotated += rotat;

        Vector2 nextPos = (Vector2)Center.transform.position
            + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
                          
        float follow = lerpFollow * bulletSpeed;   
        float t = 1f - Mathf.Exp(-follow * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, (Vector3)nextPos, t);
        radius = Mathf.MoveTowards(radius, targetRadius, radiusAdjustSpeed * Time.deltaTime);
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

    public void SetSpeed(float min, float max,float decrease ,BulletTrajectoryDataSO data)
    {
        BulletTrajectoryData = data;
        radius = BulletTrajectoryData.radius;
        this.decrease = decrease;
        targetRadius = BulletTrajectoryData.radius;
        maxCircleMove = Mathf.PI * 2f * BulletTrajectoryData.CircleMoveAngle;
        nowState = state.Circle;
        minSpeed = min;
        bulletMaxSpeed = max;
        bulletSpeed = bulletMaxSpeed;
    }
}
