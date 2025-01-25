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

    //Inputs
    InputAction moveAction;
    InputAction jumpAction;

    //Components
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Get Inputs
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");

        //Get Components
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float yMove = 0f;
        //Get X Move
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        Debug.Log(moveValue);
        //Get Y Move
        if (jumpAction.IsPressed())
        { yMove = 1; }
        //Apply Forces
        rb.AddForce(new Vector2((moveValue.x * speed), (yMove * swimSpeed)));
        //Limit force movement, y value down is trippled for gravity
        rb.linearVelocity = new Vector2(Mathf.Clamp(rb.linearVelocityX, -maxVelocity, maxVelocity), Mathf.Clamp(rb.linearVelocityY, -maxVelocity*10, maxVelocity));

        //If pressing down increase force of gravity
        if (moveValue.y <= -0.5f)
        { rb.gravityScale = 6f; }
        else { rb.gravityScale = 1f; }
    }
}
