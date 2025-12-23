using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class YHWPlayer : MonoBehaviour
{
    [field: SerializeField] public GameObject HeadCollider { get; private set; }
    [SerializeField] public AnimatorController basicController;
    [SerializeField] public List<AnimatorOverrideController> helmetController;
    public PlayerJump JumpCompo { get; private set; }
    public PlayerHP HPCompo { get; private set; }
    public PlayerAnimation AnimCompo { get; private set; }
    public GunFiring FiringCompo { get; private set; }
    public PlayerAbility AbilityCompo { get; private set; }

    private void Awake()
    {
        JumpCompo = GetComponent<PlayerJump>();
        HPCompo = GetComponent<PlayerHP>();
        AnimCompo = GetComponentInChildren<PlayerAnimation>();
        FiringCompo = GetComponentInChildren<GunFiring>();
        AbilityCompo = GetComponent<PlayerAbility>();
    }

    private void Start()
    {
        HeadCollider.GetComponent<PlayerHitBox>()._onChangeCos += ChangeAnimController;
        HPCompo._onDie += DeleteCollider;
    }

    private void ChangeAnimController()
    {
        if (!HeadCollider.GetComponent<PlayerHitBox>().LeatherSet && !HeadCollider.GetComponent<PlayerHitBox>().IronSet)
        {
            AnimCompo.AnimCompo.runtimeAnimatorController = basicController;
        }
        else if (HeadCollider.GetComponent<PlayerHitBox>().LeatherSet && !HeadCollider.GetComponent<PlayerHitBox>().IronSet)
        {
            AnimCompo.AnimCompo.runtimeAnimatorController = helmetController[0];
        }
        else if (!HeadCollider.GetComponent<PlayerHitBox>().LeatherSet && HeadCollider.GetComponent<PlayerHitBox>().IronSet)
        {
            AnimCompo.AnimCompo.runtimeAnimatorController = helmetController[1];
        }
    }

    private void DeleteCollider()
    {
        HeadCollider.SetActive(false);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
