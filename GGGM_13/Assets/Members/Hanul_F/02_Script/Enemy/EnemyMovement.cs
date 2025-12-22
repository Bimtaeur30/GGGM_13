using Unity.Mathematics;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Speed {get {return speed;} set {speed = value;}}

    [SerializeField] private GameObject center;
    [SerializeField] private float radius = 2.25f;
    [SerializeField] private float speed = 0.3f;

    [SerializeField] private float angle;
    private float rotated = 0f;

    private float size = 0.2f;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        Vector2 dir = (Vector2)transform.position - (Vector2)center.transform.position;
        angle = Mathf.Atan2(dir.y, dir.x);

        transform.localScale = new Vector3(size, size, size);
        spriteRenderer.sortingOrder = -1;
    }

    void Update()
    {
        size = Mathf.Clamp(size + 0.3f * Time.deltaTime, 0.2f, 1f);
        if (size <= 0.9f)
        {
            radius += 0.00001f;
        }

        Vector3 target = Vector3.one * size;
        transform.localScale = Vector3.Lerp(transform.localScale, target, 6f * Time.deltaTime);

        if (size >= 0.5f)
        {
            spriteRenderer.sortingOrder = 2;
        }

        MoveMent();
    }




    public void MoveMent()
    {
        float rotat = speed * Time.deltaTime;
        angle += rotat;
        rotated += rotat;

        float x = center.transform.position.x + Mathf.Cos(angle) * radius;
        float y = center.transform.position.y + Mathf.Sin(angle) * radius;

        Vector2 nextPos = new Vector2(x, y);
        transform.position = (Vector3)nextPos;
        LookTangent();
    }

    private void LookTangent()
    {
        Vector2 tangent = new Vector2(
            -Mathf.Sin(angle),
             Mathf.Cos(angle)
        );

        float rotZ = Mathf.Atan2(tangent.y, tangent.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
