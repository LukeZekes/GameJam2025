using UnityEngine;
using UnityEngine.InputSystem;

public class CharaANIMEManager : MonoBehaviour
{
    Animator charaManager;

    InputAction jump;
    InputAction move;
    InputAction dash;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        charaManager = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       // if (PlayerAttack.)
    }
}
