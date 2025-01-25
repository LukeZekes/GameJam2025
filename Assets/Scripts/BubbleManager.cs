using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject bubblePrefab;
    [SerializeField]
    private int maxBubbleCount = 10;
    private List<Bubble> bubbles = new List<Bubble>();

    private static BubbleManager instance;
    public static BubbleManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<BubbleManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("BubbleManager");
                    instance = go.AddComponent<BubbleManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

    }

    public void SpawnBubble(Vector3 position) {
        Bubble _bubble = Instantiate(bubblePrefab, position, Quaternion.identity).GetComponent<Bubble>();
        _bubble.Setup(10, Random.Range(1f, 3f));
        bubbles.Add(_bubble);
    }

    public void DoBubbleAttack(Vector3 target) {
        foreach (Bubble bubble in bubbles) {
            bubble.StartAttack(target);
        }
    }
}
