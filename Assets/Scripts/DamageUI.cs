using UnityEngine;

public class DamageUI : MonoBehaviour
{
    void Start() {
        GetComponent<MeshRenderer>().sortingLayerID=0;
        GetComponent<MeshRenderer>().sortingOrder = 10;
    }
    public void Destroytxt()
    {
        Destroy(gameObject);
    }
}
