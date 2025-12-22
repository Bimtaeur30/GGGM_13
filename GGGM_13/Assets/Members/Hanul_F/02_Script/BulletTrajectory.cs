using UnityEngine;

public class BulletTrajectory : MonoBehaviour
{
    public BulletTrajectoryDataSO BulletTrajectoryData = null;

    public GameObject Center = null;
    private float bulletSpeed;
    private float bulletWiatTiem;
    private float radius;

    private float maxCircleMove;

    private float rotated;
    float angle;

    void Awake()
    {
        bulletSpeed = BulletTrajectoryData.bulletSpeed;
        bulletWiatTiem = BulletTrajectoryData.bulletWiatTiem;
        radius = BulletTrajectoryData.radius;
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
        bulletSpeed -= rotat/bulletSpeed;

        rotated += rotat;

        float x = Center.transform.position.x + Mathf.Cos(angle) * radius;
        float y = Center.transform.position.y + Mathf.Sin(angle) * radius;

        transform.position = new Vector2(x, y);
    }

    public void CenterSet(GameObject center)
    {
        this.Center = center;
    }
}
