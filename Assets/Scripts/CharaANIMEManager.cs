using UnityEngine;
using UnityEngine.InputSystem;

public class CharaANIMEManager : MonoBehaviour
{
    Animator charaManager;
    [SerializeField]
    PlayerMovement PlayerM;
    [SerializeField]
    PlayerAttack PlayerA;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        charaManager = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        charaManager.ResetTrigger("isDash");
        charaManager.ResetTrigger("isJump");
        charaManager.ResetTrigger("Chain1");
        charaManager.ResetTrigger("Chain2");
        charaManager.ResetTrigger("Chain3");
        charaManager.ResetTrigger("Special");
    }

    // Update is called once per frame
    void Update()
    {
        //Movement Animation
        Vector2 moveValue = PlayerM.moveAction.ReadValue<Vector2>();
        if (moveValue.x < 0)
        {
            charaManager.SetBool("isMove", true);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            Debug.Log("Move Animation");
        }
        else if (moveValue.x > 0)
        {
            charaManager.SetBool("isMove", true);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            Debug.Log("Move Animation");
        }
        else
        {
            charaManager.SetBool("isMove", false);
        }

       //Dashing Animation
       if (PlayerM.dashing)
       {
           charaManager.SetTrigger("isDash");


            Debug.Log("Dash Animation");
       }

       //Jumping Animation
       if (PlayerM.jumpAction.IsPressed())
       {
           charaManager.SetTrigger("isJump");
            Debug.Log("Jump Animation");
        }

       //Attack Chain Animation
       if (PlayerA.one)
        {
            charaManager.SetTrigger("Chain1");
            Debug.Log("Attack1 Animation");
        }

        if (PlayerA.two)
        {
            charaManager.SetTrigger("Chain2");
            Debug.Log("Attack2 Animation");
        }

        if (PlayerA.three)
        {
            charaManager.SetTrigger("Chain3");
            Debug.Log("Attack3 Animation");
        }

        //Special Animation
        if (PlayerA.bub)
        {
            charaManager.SetTrigger("Special");
            Debug.Log("Special Animation");
        }

    }
}
