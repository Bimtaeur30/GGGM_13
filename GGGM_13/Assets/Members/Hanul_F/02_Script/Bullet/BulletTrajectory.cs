using UnityEngine;

public class BulletTrajectory : MonoBehaviour, IBullet
{
    [SerializeField] private BulletTrajectoryDataSO data;

    [Header("Train Settings")]
    [SerializeField] private float angleSpacing = 0.25f; // 탄 간 각도 간격

    [Header("Smooth Settings")]
    [SerializeField] private float positionSmooth = 10f;

    private GameObject center;
    private BulletTrajectory frontBullet;

    private float angle;
    private float radius;
    private float speed;

    private bool initialized;

    private void Awake()
    {
        speed = data.bulletSpeed;
        radius = data.radius;
    }

    public void SetCenter(GameObject center)
    {
        this.center = center;

        Vector2 dir = (Vector2)transform.position - (Vector2)center.transform.position;
        angle = Mathf.Atan2(dir.y, dir.x);

        initialized = true;
    }

    public void SetFrontBullet(IBullet front)
    {
        frontBullet = front as BulletTrajectory;
    }

    private void Update()
    {
        if (!initialized || center == null)
            return;

        CircleMove();
    }

    private void CircleMove()
    {
        float rot = speed * Time.deltaTime;
        float nextAngle = angle - rot;

        // 🚆 기차 핵심 로직 (앞 탄보다 더 못 가게 제한)
        if (frontBullet != null)
        {
            float limitAngle = frontBullet.angle + angleSpacing;
            angle = Mathf.Max(nextAngle, limitAngle);
        }
        else
        {
            angle = nextAngle;
        }

        // 목표 위치 계산
        Vector2 desiredPos =
            (Vector2)center.transform.position +
            new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;

        // ⭐ 위치 스무딩 (순간이동 방지)
        transform.position = Vector2.Lerp(
            transform.position,
            desiredPos,
            Time.deltaTime * positionSmooth
        );
    }
}
