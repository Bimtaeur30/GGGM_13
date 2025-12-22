using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private PlayerJump playerJump;

    private int _isGround = Animator.StringToHash("IsGround");

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        playerJump = GetComponentInParent<PlayerJump>();
    }

    private void Update()
    {
        _anim.SetBool(_isGround, playerJump.IsGround);
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
