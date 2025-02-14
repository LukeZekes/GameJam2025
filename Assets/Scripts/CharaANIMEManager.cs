using UnityEngine;

public class CharaANIMEManager : MonoBehaviour
{
    Animator charaManager;
    PlayerMovement PlayerM;
    PlayerAttack PlayerA;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        charaManager = GetComponent<Animator>();
        PlayerM = GetComponentInParent<PlayerMovement>();
        PlayerA = GetComponentInParent<PlayerAttack>();
    }

    void FixedUpdate()
    {
        charaManager.ResetTrigger("Dash");
        charaManager.ResetTrigger("Jump");
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
        charaManager.SetFloat("X", moveValue.x);
        charaManager.SetFloat("Y", moveValue.y);
        charaManager.SetFloat("AbsX", Mathf.Abs(moveValue.x));
        charaManager.SetFloat("AbsY", Mathf.Abs(moveValue.y));
        if (moveValue.x < 0)
        {
            charaManager.SetBool("isMove", true);
            transform.rotation = Quaternion.Euler(0, 180, 0);
           // Debug.Log("Move Animation");
        }
        else if (moveValue.x > 0)
        {
            charaManager.SetBool("isMove", true);
            transform.rotation = Quaternion.Euler(0, 0, 0);
           // Debug.Log("Move Animation");
        }
        else
        {
            charaManager.SetBool("isMove", moveValue.y != 0);
        }

       //Jumping Animation
       if (PlayerM.jumpAction.IsPressed())
        {
           charaManager.SetTrigger("Jump");
        }

        //Dashing Animation
       if (PlayerM.dashing)
       {
            charaManager.SetTrigger("Dash");
       }

       //Attack Chain Animation
       if (PlayerA.one)
        {
            charaManager.SetTrigger("Chain1");
            PlayerA.one = false;
           // Debug.Log("Attack1 Animation");
        }

        if (PlayerA.two)
        {
            charaManager.SetTrigger("Chain2");
            PlayerA.two = false;
           // Debug.Log("Attack2 Animation");
        }

        if (PlayerA.three)
        {
            charaManager.SetTrigger("Chain3");
            PlayerA.three = false;
           // Debug.Log("Attack3 Animation");
        }

        //Special Animation
        if (PlayerA.bub)
        {
            charaManager.SetTrigger("Special");
            PlayerA.bub = false;
            Debug.Log("Special Animation");
        }

    }
}
