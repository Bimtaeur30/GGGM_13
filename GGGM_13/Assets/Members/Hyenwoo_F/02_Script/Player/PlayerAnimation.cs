using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private PlayerJump playerJump;

    private readonly int _isGround = Animator.StringToHash("IsGround");
    private readonly int _velocityY = Animator.StringToHash("VelocityY");
    private readonly int _attackIndex = Animator.StringToHash("AttackIndex");
    private readonly int _isAttack = Animator.StringToHash("IsAttacking");
    private GunFiring _gunFiring;
    private GunAnimation _gunAnimation;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        playerJump = GetComponentInParent<PlayerJump>();
        _gunFiring = playerJump.GetComponentInChildren<GunFiring>();
        _gunAnimation = _gunFiring.GetComponentInChildren<GunAnimation>();
        _gunFiring._onAttack += StartAttackAnimation;
        _gunAnimation._onAttackEnd += EndAttackAnimation;
    }

    private void Update()
    {
        _anim.SetBool(_isGround, playerJump.IsGround);
        _anim.SetFloat(_velocityY, playerJump.RigidCompo.linearVelocityY);
    }

    private void StartAttackAnimation()
    {
        _anim.SetBool(_isAttack, true);
        _anim.SetInteger(_attackIndex, Random.Range(0, 3));
    }

    private void EndAttackAnimation()
    {
        _anim.SetBool(_isAttack, false);
        _anim.SetInteger(_attackIndex, 3);
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
