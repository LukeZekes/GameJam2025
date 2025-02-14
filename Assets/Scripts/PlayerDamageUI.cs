using UnityEngine;
using TMPro;

public class PlayerDamageUI : MonoBehaviour
{
    public GameObject damagePrefab;
    public WeaponCheck weapon;
    public string txtDisplay;
    public GameObject bubbles;
    // Update is called once per frame

    void SpawnTxt(int damage)
    {
        GameObject Damagetxt = Instantiate(damagePrefab, transform);
        if (transform.GetChild(1).eulerAngles.y == 180)
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
    public void Attacking(bool hit, int damage, Vector3 postion)
    {
        if (hit == true)
        {
            SpawnBubbleTxt(damage, postion);
        }
    }
    void SpawnBubbleTxt(int damage, Vector3 pos)
    {
        GameObject Damagetxt = Instantiate(damagePrefab, pos,Quaternion.identity);
        txtDisplay = damage.ToString();
        Damagetxt.GetComponent<TextMeshPro>().SetText(txtDisplay);
    }
    
}
