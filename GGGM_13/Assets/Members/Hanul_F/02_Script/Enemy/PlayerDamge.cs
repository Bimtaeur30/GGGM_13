using UnityEngine;

public class PlayerDamge : MonoBehaviour
{
    [SerializeField] private GameObject attackParticle;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHP>(out PlayerHP playerHP))
        {
            playerHP.GetDamage(1);
            GameObject particle = Instantiate(attackParticle, gameObject.transform.position, Quaternion.identity);
            particle.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
        }
    }
}
