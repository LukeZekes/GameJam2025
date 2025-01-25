using UnityEngine;

public class DamageUI : MonoBehaviour
{
    public void DestroyParent()
    {
        GameObject parent = gameObject.transform.parent.gameObject;
        Destroy(parent);
    }
}
