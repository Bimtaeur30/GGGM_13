using UnityEngine;

public interface IBullet
{
    public void SetCenter(GameObject center);

    public void SetFrontBullet(IBullet front);
}
