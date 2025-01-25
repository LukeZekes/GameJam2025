using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Values can be changed in editor, clamp and speed values
    [SerializeField]
    float speed = 10f;
    [SerializeField]
    float maxVelocity = 30f;
    [SerializeField]
    float swimSpeed = 5f;
    [SerializeField]
    float dashMult = 5f;

    //Dash Variables
    float dashTimer = 0f;
    float DashCoolown = 2.2f;
    bool dashed = false;
    bool dashing = false;
    Vector2 dashTarget;
    float dashDistance;
    float dashAngle;

    //Inputs
    InputAction moveAction;
    InputAction jumpAction;
    InputAction dashAction;

    //Components
    Rigidbody2D rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Get Inputs
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        dashAction = InputSystem.actions.FindAction("Sprint");

        //Get Components
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get X Move
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        //dashing overrides other movement calcs
        if (dashing)
        {
            DashMove();
        }
        else
        {
            float yMove = 0f;
            //Get Y Move
            if (jumpAction.IsPressed())
            { yMove = 1; }
            //Apply Forces
            rb.AddForce(new Vector2((moveValue.x * speed), (yMove * swimSpeed)));
            //Limit force movement, y limit down is increrased for gravity.
            rb.linearVelocity = new Vector2(Mathf.Clamp(rb.linearVelocityX, -maxVelocity, maxVelocity), Mathf.Clamp(rb.linearVelocityY, -maxVelocity*10, maxVelocity));

            //If pressing down increase force of gravity
            if (moveValue.y <= -0.5f)
            { rb.gravityScale = 6f; }
            else { rb.gravityScale = 1f; }
        }
        //If dash pressed, then dash
        if (dashed)
        {
            if (dashTimer < DashCoolown)
            {
                dashTimer+= Time.deltaTime;
            }
            else
            { dashed = false; }
        }
        else if (dashAction.IsPressed())
        {
            //Pain
            //Also this gets the trig values for calulating components of velocity
            //Then it sets values for dashing and removes the resistance for dashing
            dashTarget = new Vector2(moveValue.x*(speed*1.5f), moveValue.y*(speed*1.5f));
            Debug.Log(dashTarget);
            dashDistance = Vector2.Distance(Vector2.zero, dashTarget);
            Debug.Log(dashDistance);
            dashAngle = Vector2.SignedAngle(Vector2.right, dashTarget);
            Debug.Log(dashAngle);
            dashing = true;
            dashed = true;
            dashTimer = 0f;
            rb.linearDamping = 0;

            //TODO: Add invuln state in dash
            //TODO: spawn big bubble on opocite side from direction player is dashing
        }
    }

    void DashMove()
    {
        if (dashTimer < 0.1f)
        {
            //FUCK U UNITY TRIG FUNCTIONS AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
            rb.linearVelocity = new Vector2((dashDistance * Mathf.Cos(Mathf.Deg2Rad * dashAngle)),(dashDistance * Mathf.Sin(Mathf.Deg2Rad * dashAngle))) * dashMult;
            Debug.Log(rb.linearVelocity);
        }
        else
        {
            //The pain is over now
            dashing = false;
            rb.linearDamping = 3;
            //rb.linearVelocity = Vector2.zero;

            //TODO: Reenable the ability to die, not because the dashing code is painful but because the player needs to be able to be hurt now
        }
    }
}
