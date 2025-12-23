using UnityEngine;

public interface IBullet
{
    public void SetCenter(GameObject center);

    public void SetSpeed(float min, float max,float decrease,BulletTrajectoryDataSO data);
}
