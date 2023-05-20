using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class MainGun : MonoBehaviour
{

    public Vector2 aimInput;
    public Vector2 aimDirection;

    public AntHillStats stats;

    public GameObject mainGun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Aim(InputAction.CallbackContext context)
    {
        aimInput = context.ReadValue<Vector2>();
        //Debug.Log(InputManagerScript.playerInput.currentControlScheme.ToString());
        if (InputManagerScript.playerInput.currentControlScheme == "Keyboard&Mouse")
        {
            aimInput = Camera.main.ScreenToWorldPoint(aimInput).normalized;
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        aimDirection = Vector2.MoveTowards(aimDirection, aimInput, Time.fixedDeltaTime * stats.aimSpeed);
        
        
        //mainGun.transform.rotation = Quaternion.Euler(aimDirection.x, aimDirection.y, 0);
        mainGun.transform.right = aimDirection - new Vector2(mainGun.transform.position.x, mainGun.transform.position.y) ;

    }
}
