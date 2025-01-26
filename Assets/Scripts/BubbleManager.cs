using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject bubblePrefab;
    [SerializeField]
    private int maxBubbleCount = 100;
    [SerializeField]
    private List<Bubble> bubbles = new List<Bubble>();

    //Provide size range, identical min amd max provide the value as size
    //Small = 0.5f-0.2f
    //Medium = 0.6f-0.7f
    //Learge = 2f
    public void SpawnBubble(Vector3 position, float minSize, float maxSize) {
        Bubble _bubble = Instantiate(bubblePrefab, position, Quaternion.identity).GetComponent<Bubble>();
        if (minSize == maxSize)
        {
            _bubble.Setup(Random.Range(8f, 11f), minSize);
        }
        else
        {
            _bubble.Setup(Random.Range(8f, 11f), Random.Range(minSize, maxSize));
        }
        bubbles.Add(_bubble);
    }

    public void DoBubbleAttack(Vector3 target) {
        foreach (Bubble bubble in bubbles) {
            if (bubble != null)
            {bubble.StartAttack(target);}
        }
    }

    public void CleanList(Bubble pop)
    {
        if (bubbles.Contains(pop))
        {
            bubbles.Remove(pop);
        }
    }
}
