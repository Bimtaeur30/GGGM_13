using JetBrains.Annotations;
using UnityEngine;

public class RunSFX : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public void PlayerRunSFX()
    {
        audioSource.Play();
    }

    public void StopRunSFX()
    {
        audioSource.Stop();
    }
}
