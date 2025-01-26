using UnityEngine;

public class PlayerLighting : MonoBehaviour
{
    private int textureSize;
    private float levelHeight = 110f;
    [SerializeField] private Texture2D gradientTexture;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        textureSize = gradientTexture.height;
    }

    void Update()
    {
        float normalizedPosition = (transform.position.y + 55)/ levelHeight;
        spriteRenderer.color = SampleGradient(normalizedPosition);
    }

    public Color SampleGradient(float position)
    {
        position = Mathf.Clamp01(position);
        //Debug.Log(position);
        int pixelPosition = Mathf.RoundToInt(position * (textureSize - 1));

        return gradientTexture.GetPixel(0, pixelPosition);
    }
}
