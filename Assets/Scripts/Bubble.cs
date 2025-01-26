using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField]
    GameObject PopPrefab;
    private Vector2 target;
    private Vector2 targetDirection;
    private float speed;
    private bool isMoving;
    private float size;
    private float maxTravelDistance = 1000;
    private float distanceTraveled;
    private float delay;
    private bool startDelay;
    // Called by BubbleManager when the bubble is spawned
    public void Setup(float speed, float size)
    {
        startDelay = false;
        isMoving = false;
        this.speed = speed;
        this.transform.localScale *= size;
        distanceTraveled = 0;
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        rb.gravityScale = -1 * Random.Range(0.1f, 0.2f);
        float time = 3f + (3f*size) + Random.Range(-0.1f, 0.1f);
        Destroy(gameObject, time);
    }

    public void StartAttack(Vector3 target)
    {
        delay = Random.value;
        this.target = target; // Multiply by 500 to make the bubbe travel far along that direction
        startDelay = true;
        targetDirection = target;
    }

    void Update()
    {
        if (startDelay)
        {
            delay -= Time.deltaTime;
            if (delay <= 0)
            {
                startDelay = false;
                isMoving = true;
            }
        }
        if (isMoving)
        {
            float moveStep = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetDirection, moveStep);
            distanceTraveled += moveStep;
            if ( (distanceTraveled >= maxTravelDistance) || Mathf.Abs(Vector3.Distance(transform.position, targetDirection)) < 1 )
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (isMoving)
        {
            if (col.gameObject.tag == "Fish" || col.gameObject.tag == "Shark" || col.gameObject.tag == "Eel") {
                col.gameObject.SendMessage("Hit", 1);
                Pop();
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
        popScript _pop = Instantiate(PopPrefab, transform.position, Quaternion.identity).GetComponent<popScript>();
        _pop.Setup(transform);

        BubbleManager.Instance.CleanList(this.GetComponent<Bubble>());
    }
}
 