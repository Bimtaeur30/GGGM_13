
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class GunFiring : MonoBehaviour
{
    [Header("TargetChecker")]
    [SerializeField] private Transform _targetCheckerTrm;
    [SerializeField] private float _targetCheckerSize;
    [Header("Gun")]
    [SerializeField] private Transform _gun;
    private float _desireAngle;
    private GameObject target;
    private GameObject currentTarget;
    private bool isTargeting;

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            currentTarget = LockForTarget();
            isTargeting = true;
        }

        if (isTargeting == true)
        {
            ShotAnim(currentTarget.transform.position);
        }
    }

    private void ShotAnim(Vector2 pos)
    {
        Vector2 dir = pos - (Vector2)transform.position;
        _desireAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        _gun.rotation = Quaternion.Euler(0, 0, _desireAngle);
    }

    private GameObject LockForTarget()
    {
        target = null;

        Collider2D[] targetList = Physics2D.OverlapCircleAll(_targetCheckerTrm.position, _targetCheckerSize);

        foreach (var item in targetList)
        {
            if (item.TryGetComponent<Target>(out Target tg))
            {
                if (target == null)
                {
                    target = tg.gameObject;
                }
                else if (Vector3.Distance(transform.position, target.transform.position)
                    > Vector3.Distance(transform.position, tg.transform.position))
                {
                    target = tg.gameObject;
                }

            }
        }
        if (target == null)
            return null;
        else
            return target;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_targetCheckerTrm.position, _targetCheckerSize);
    }
}
