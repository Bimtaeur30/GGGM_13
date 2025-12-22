using System.Collections;
using Unity.VisualScripting;
using Unity.XR.OpenVR;
using UnityEngine;

public class Rabbit : Enemy
{
    [SerializeField] private GameObject deathParticle;
    protected override void OnDeath()
    {
        Instantiate(deathParticle,gameObject.transform.position,Quaternion.identity);
    }

    protected override IEnumerator Remove()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
