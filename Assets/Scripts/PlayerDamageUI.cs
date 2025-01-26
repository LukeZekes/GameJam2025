using UnityEngine;
using TMPro;

public class PlayerDamageUI : MonoBehaviour
{
    public GameObject damagePrefab;
    public GameObject player;
    public WeaponCheck weapon;
    public string txtDisplay;

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnTxt(int damage)
    {
       GameObject Damagetxt =  Instantiate(damagePrefab, player.transform);
        GameObject temp = GameObject.Find("PlayerSprite");
        if (temp.transform.eulerAngles.y == 180)
        {
            Damagetxt.GetComponent<TextMeshPro>().alignment = TextAlignmentOptions.Left;
        }
        else
        {
            Damagetxt.GetComponent<TextMeshPro>().alignment = TextAlignmentOptions.Right;
        }
        txtDisplay = damage.ToString();
        Damagetxt.GetComponent<TextMeshPro>().SetText(txtDisplay);
    }
    public void Attacking(bool hit, int damage)
    {
        if (hit == true)
        {
            SpawnTxt(damage);
        }
    }
}
