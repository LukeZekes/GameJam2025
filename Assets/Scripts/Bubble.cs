using UnityEngine;

public class Bubble : MonoBehaviour
{
    private Vector2 target;
    private Vector2 targetDirection;
    private float speed;
    private bool isMoving;
    private float size;
    private float maxTravelDistance = 1000;
    private float distanceTraveled;
    // Called by BubbleManager when the bubble is spawned
    public void Setup(float speed, float size)
    {
        isMoving = false;
        this.speed = speed;
        this.transform.localScale *= size;
        distanceTraveled = 0;
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        rb.gravityScale = -1 * Random.Range(0.1f, 0.2f);
        float time = 3f + (3f*size);
        Destroy(gameObject, time);
    }

    public void StartAttack(Vector3 target)
    {
        this.target = target; // Multiply by 500 to make the bubbe travel far along that direction
        isMoving = true;
        targetDirection = (target - transform.position).normalized;
    }

    void Update()
    {
        if (isMoving)
        {
            float moveStep = speed * Time.deltaTime;
            Debug.Log("asA");
            transform.Translate(targetDirection * moveStep);
            distanceTraveled += moveStep;
            if (distanceTraveled >= maxTravelDistance)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Pop()
    {
        // Put some effects or sounds or something here
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        GameObject temp = GameObject.Find("BubbleManager");
        BubbleManager bm = temp.GetComponent<BubbleManager>();
        bm.CleanList(this.GetComponent<Bubble>());
    }
}
