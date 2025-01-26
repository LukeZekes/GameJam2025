using UnityEngine;
using UnityEngine.InputSystem;

public class CharaANIMEManager : MonoBehaviour
{
    Animator charaManager;
    [SerializeField]
    PlayerMovement Player;

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
        Vector2 moveValue = Player.moveAction.ReadValue<Vector2>();
        if (moveValue.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (moveValue.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
       // if (PlayerAttack.)
    }
}
