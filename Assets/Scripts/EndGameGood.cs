using UnityEngine;

public class EndGameGood : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            //do the thing
        }
    }
}
