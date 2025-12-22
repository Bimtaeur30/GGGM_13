using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private PlayerJump playerJump;

    private int _isGround = Animator.StringToHash("IsGround");
    private int _velocityY = Animator.StringToHash("VelocityY");

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        playerJump = GetComponentInParent<PlayerJump>();
    }

    private void Update()
    {
        _anim.SetBool(_isGround, playerJump.IsGround);
        _anim.SetFloat(_velocityY, playerJump.RigidCompo.linearVelocityY);
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
