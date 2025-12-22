using UnityEngine;

[CreateAssetMenu(fileName = "BulletTrajectoryData", menuName = "Scriptable Objects/BulletTrajectoryDataSO")]
public class BulletTrajectoryDataSO : ScriptableObject
{
    [Range(0,10)]
    public float bulletSpeed = 2f;

    public float bulletWiatTiem => Random.Range(0f,10f);

    [Range(1,50)]
    public float radius = 2f;

    [Range(0,1f)]
    public float CircleMoveAngle = 0.8f;
}
