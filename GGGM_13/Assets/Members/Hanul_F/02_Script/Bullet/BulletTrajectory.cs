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

    private float firstLerpTiem = 0.2f;

    private float timer = 0f;

    private state nowState;

    private Vector3 straightMove;

    private float targetRadius;

    void Update()
    {
        switch (nowState)
        {
            case state.Start:
                // FristCircleMove();
                timer += Time.deltaTime;
                StraightMoving();
                if (timer >= firstLerpTiem)
                {
                    timer = 0f;

                    Vector2 dir = (Vector2)transform.position - (Vector2)Center.transform.position;
                    if (dir.sqrMagnitude < 0.000001f) dir = Vector2.right;

                    angle = Mathf.Atan2(dir.y, dir.x);

                    radius = dir.magnitude;   // ⭐ 현재 위치 기준 반지름으로!
                    rotated = 0f;             // (풀링이면 특히 필수)

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

        float t = 1f - Mathf.Exp(-lerpFollow * Time.deltaTime); // ✅ 올바른 t
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
        targetRadius = BulletTrajectoryData.radius;
        maxCircleMove = Mathf.PI * 2f * BulletTrajectoryData.CircleMoveAngle;
        nowState = state.Start;
        minSpeed = min;
        bulletMaxSpeed = max;
        bulletSpeed = bulletMaxSpeed;
    }
}
