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
        SpawnTxt();
    }
    void SpawnTxt()
    {
       GameObject Damagetxt =  Instantiate(damagePrefab, player.transform);
        Damagetxt.GetComponent<TextMeshProUGUI>().SetText(txtDisplay);
    }
}
