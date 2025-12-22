using UnityEngine;

public class YHWBUllet : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D _rigid;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigid.linearVelocityX = speed * 1;
    }
}
