using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rigidbody;
    public PlayerStats stats;
    public PlayerMagnet magnet;

    public Vector2 movementInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Move(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
            rigidbody.velocity = Vector2.MoveTowards(rigidbody.velocity, movementInput * stats.movementSpeed, Time.fixedDeltaTime * stats.movementSpeed * stats.movementAcceleration);
        if (rigidbody.velocity != Vector2.zero)
        {
            var velocity = rigidbody.velocity;
            float angleInRadian = Mathf.Atan2(velocity.y, velocity.x);
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, (Mathf.Rad2Deg * angleInRadian) - 90));
            gameObject.transform.rotation = rotation;
        }
    }
}
