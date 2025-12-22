using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class YHWPlayer : MonoBehaviour
{
    [field: SerializeField] public GameObject HeadCollider { get; private set; }
    [field: SerializeField] public List<AnimatorController> AnimControllers;
    public PlayerJump JumpCompo { get; private set; }
    public PlayerHP HPCompo { get; private set; }
    public PlayerAnimation AnimCompo { get; private set; }
    public GunFiring FiringCompo { get; private set; }

    private void Awake()
    {
        JumpCompo = GetComponent<PlayerJump>();
        HPCompo = GetComponent<PlayerHP>();
        AnimCompo = GetComponentInChildren<PlayerAnimation>();
        FiringCompo = GetComponentInChildren<GunFiring>();
    }

    private void ChangeAnimController()
    {
    }
}
