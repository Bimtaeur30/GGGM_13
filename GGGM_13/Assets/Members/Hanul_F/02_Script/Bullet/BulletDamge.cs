using UnityEngine;

public class BulletDamge : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damge))
        {
            damge.GetDamage(1, gameObject);
        }

        if ((playerLayer.value & (1 << collision.gameObject.layer)) == 0)
            return;

        if (collision.gameObject.TryGetComponent<PlayerHP>(out PlayerHP playerHP))
        {
            playerHP.GetDamage(1);
            Destroy(gameObject);
        }
    }
}
