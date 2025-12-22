using UnityEngine;

public class BulletDamge : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damge))
        {
            damge.GetDamage(1, gameObject);
        }

        if (collision.gameObject.TryGetComponent<PlayerHP>(out PlayerHP playerHP))
        {
            playerHP.GetDamage(1);
            Destroy(gameObject);
        }
    }
}
