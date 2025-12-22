using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject center;
    [SerializeField] private float radius = 2f;
    [SerializeField] private float speed = 2f;

    [SerializeField] private float angle;
    private float rotated = 0f;

    private float timer = 0f;

    private float size = 0.2f;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        angle = math.PI;

        transform.localScale = new Vector3(size,size,size);
        spriteRenderer.sortingOrder = -1;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 10)
        {
            size += 0.1f;
            size = Mathf.Clamp(size,0.2f, 1f);
            transform.localScale = new Vector3(size,size,size);
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
