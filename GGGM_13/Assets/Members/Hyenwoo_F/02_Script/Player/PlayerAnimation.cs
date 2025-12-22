using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void AnimationSpeedUp(int speedValue)
    {
        _anim.speed += speedValue;
    }

    public void AnimationSpeedDown(int speedValue)
    {
        _anim.speed -= speedValue;
    }
}
