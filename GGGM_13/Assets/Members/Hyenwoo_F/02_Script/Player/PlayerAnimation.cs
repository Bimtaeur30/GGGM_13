using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator AnimCompo { get; private set; }
    private PlayerJump playerJump;

    private readonly int _isGround = Animator.StringToHash("IsGround");
    private readonly int _velocityY = Animator.StringToHash("VelocityY");
    private readonly int _attackIndex = Animator.StringToHash("AttackIndex");
    private readonly int _isAttack = Animator.StringToHash("IsAttacking");
    private readonly int _isHit = Animator.StringToHash("IsHit");
    private readonly int _isDie = Animator.StringToHash("IsDie");
    private GunFiring _gunFiring;
    private GunAnimation _gunAnimation;

    private void Awake()
    {
        AnimCompo = GetComponent<Animator>();
        playerJump = GetComponentInParent<PlayerJump>();
        _gunFiring = playerJump.GetComponentInChildren<GunFiring>();
        _gunAnimation = _gunFiring.GetComponentInChildren<GunAnimation>();
        _gunFiring._onAttack += StartAttackAnimation;
        _gunAnimation._onAttackEnd += EndAttackAnimation;
    }

    private void Update()
    {
        AnimCompo.SetBool(_isGround, playerJump.IsGround);
        AnimCompo.SetFloat(_velocityY, playerJump.RigidCompo.linearVelocityY);
    }

    private void StartAttackAnimation()
    {
        AnimCompo.SetBool(_isAttack, true);
        AnimCompo.SetInteger(_attackIndex, Random.Range(0, 2));
    }

    private void EndAttackAnimation()
    {
        AnimCompo.SetBool(_isAttack, false);
        AnimCompo.SetInteger(_attackIndex, 3);
    }

    public void AnimationSpeedUp(int speedValue)
    {
        AnimCompo.speed += speedValue;
    }

    public void AnimationSpeedDown(int speedValue)
    {
        AnimCompo.speed -= speedValue;
    }
}
