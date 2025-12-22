using UnityEngine;

public class PlayerDamge : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHP>(out PlayerHP playerHP))
        {
            playerHP.GetDamage(1);
        }
    }
}
