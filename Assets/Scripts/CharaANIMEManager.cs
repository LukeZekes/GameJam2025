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

        jump = InputSystem.actions.FindAction("Jump");
        move = InputSystem.actions.FindAction("Move");
        dash = InputSystem.actions.FindAction("Sprint");

        charaManager.SetBool("isMove", true);

    }

    // Update is called once per frame
    void Update()
    {
        //if (MOVE)
        {
            charaManager.SetBool("isMove", true);
        }



        //if (DASH)
        {
            //charaManager.SetTrigger("isMove", true);
        }

        //if (JUMP)
        {

        }

        //if (Attack)
        {

        }

        //if (
    }
}
