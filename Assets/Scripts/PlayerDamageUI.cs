using UnityEngine;
using TMPro;

public class PlayerDamageUI : MonoBehaviour
{
    public GameObject damagePrefab;
    public GameObject player;
    public string txtDisplay;

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnTxt()
    {
       GameObject Damagetxt =  Instantiate(damagePrefab, player.transform);
        GameObject temp = GameObject.Find("Pearl Idle_0");
        if (temp.transform.eulerAngles.y == 180)
        {
            Damagetxt.GetComponent<TextMeshPro>().alignment = TextAlignmentOptions.Left;
        }
        else
        {
            Damagetxt.GetComponent<TextMeshPro>().alignment = TextAlignmentOptions.Right;
        }
        Damagetxt.GetComponent<TextMeshPro>().SetText(txtDisplay);
    }
    public void Attcking(bool hit)
    {
        if (hit == true)
        {
            SpawnTxt();
        }
    }
}
