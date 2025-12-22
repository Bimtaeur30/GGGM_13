using System;
using UnityEngine;

public class GunAnimation : MonoBehaviour
{
    private Animator _anim;
    private PlayerJump playerJump;
    private GunFiring gunFiring;
    public event Action _onAttackEnd;

    private readonly int _isGround = Animator.StringToHash("IsGround");
    private readonly int _isAttacking = Animator.StringToHash("IsAttacking");

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        gunFiring = GetComponentInParent<GunFiring>();
    }

    private void Start()
    {
        playerJump = YHWGameManager.Instance.Player.GetComponent<PlayerJump>();
        gunFiring._onAttack += () => _anim.SetBool(_isAttacking, true);
    }

    private void Update()
    {
        _anim.SetBool(_isGround, playerJump.IsGround);
    }

    public void AttackEnd()
    {
        _onAttackEnd?.Invoke();
        _anim.SetBool(_isAttacking, false);
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
