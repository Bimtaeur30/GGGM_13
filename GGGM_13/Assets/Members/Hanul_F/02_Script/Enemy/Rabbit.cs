using System.Collections;
using Unity.VisualScripting;
using Unity.XR.OpenVR;
using UnityEngine;

public class Rabbit : Enemy
{
    [SerializeField] private GameObject deathParticle;
    [SerializeField] private GameObject deathMessage;

    protected override void OnDamge()
    {
        
    }

    protected override void OnDeath()
    {
        GameObject particle  = Instantiate(deathParticle,gameObject.transform.position,Quaternion.identity);
        Instantiate(deathMessage,transform.position,Quaternion.identity);
        particle.GetComponent<ParticleSystem>().Play();
    }

    protected override IEnumerator Remove()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
