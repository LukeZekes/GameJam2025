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
    [SerializeField]
    float DashCoolown = 2.2f;
    bool dashed = false;
    bool dashing = false;
    Vector2 dashTarget;
    float dashDistance;
    float dashAngle;
    Transform DashBubblePoint; //USE GLOBAL POSITION
    int dashBubbles;
    bool dashDampen;

    float endLevelHeight;
    //Inputs
    public InputAction moveAction;
    InputAction jumpAction;
    InputAction dashAction;

    //Components
    Rigidbody2D rb;
    BubbleManager bm;

    //Freeze
    [SerializeField]
    bool Freeze;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Get Inputs
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        dashAction = InputSystem.actions.FindAction("Sprint");

        //Get Components
        rb = gameObject.GetComponent<Rigidbody2D>();
        bm = BubbleManager.Instance;
        GameObject temp = GameObject.Find("DashBubblePoint");
        DashBubblePoint = temp.transform;

        endLevelHeight = GameObject.Find("EndLevelPoint").transform.position.y;
        Freeze = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Freeze)
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
                if (dashDampen)
                {
                    dashDampen = false;
                    rb.linearVelocity /= 2;
                }
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
                dashDistance = Vector2.Distance(Vector2.zero, dashTarget);
                dashAngle = Vector2.SignedAngle(Vector2.right, dashTarget);
                dashing = true;
                dashed = true;
                dashTimer = 0f;
                rb.linearDamping = 0;
                dashBubbles = 10;

                //TODO: Add invuln state in dash
                //TODO: spawn big bubble on opocite side from direction player is dashing
                Vector3 backBubbleTarget = new Vector3(dashTarget.x, dashTarget.y, 0) * -1;
                backBubbleTarget.Normalize();
                backBubbleTarget *= 3;
                backBubbleTarget += transform.position;
                bm.SpawnBubble(backBubbleTarget, 2, 2);
            }
        }

        if (transform.position.y >= endLevelHeight) {
            GameManager.WinGame();
        }
    }

    void DashMove()
    {
        if (dashTimer < 0.1f)
        {
            //FUCK U UNITY TRIG FUNCTIONS AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
            rb.linearVelocity = new Vector2((dashDistance * Mathf.Cos(Mathf.Deg2Rad * dashAngle)),(dashDistance * Mathf.Sin(Mathf.Deg2Rad * dashAngle))) * dashMult;
            if (dashBubbles > 0)
            {
                bm.SpawnBubble((DashBubblePoint.position + new Vector3 ( Random.Range(-0.5f, 0.5f),Random.Range(-0.5f, 0.5f), 0 )), 0.6f, 0.7f);
                dashBubbles--;
            }
        }
        else
        {
            //The pain is over now
            dashing = false;
            rb.linearDamping = 3;
            //If any bubbles not made. spawn them
            if (dashBubbles > 0)
            {
                for (int i = 0; i < dashBubbles; i++)
                {
                    bm.SpawnBubble((DashBubblePoint.position + new Vector3 ( Random.Range(-0.5f, 0.5f),Random.Range(-0.5f, 0.5f), 0 )), 0.6f, 0.7f);
                }
            }
            //rb.linearVelocity = Vector2.zero;
            //TODO: Reenable the ability to die, not because the dashing code is painful but because the player needs to be able to be hurt now
        }
    }

    public void FreezeManager(bool freezeSwitch)
    {
        if (freezeSwitch == true)
        {
            Freeze = true;
             rb.gravityScale = 0;
             rb.linearVelocity = Vector2.zero;
        }
        else
        {
            Freeze = false;
            rb.gravityScale = 1;
        }
    }
}
