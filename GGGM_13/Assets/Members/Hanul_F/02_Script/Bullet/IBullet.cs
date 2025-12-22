using UnityEngine;

public interface IBullet
{
    public void SetCenter(GameObject center);

    public void SetSpeed(float min, float max, BulletTrajectoryDataSO data);
}
