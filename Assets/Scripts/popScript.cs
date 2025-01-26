using UnityEngine;

public class popScript : MonoBehaviour
{
    public void Setup(Transform trans)
    {
        transform.localScale = trans.localScale;
        Destroy(gameObject, 0.2f);
    }
}
