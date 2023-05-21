using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class TurretGun : MonoBehaviour
{

    public Vector2 aimInput;
    public Vector2 aimDirection;

    public AntHillStats stats;

    public GameObject mainGun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   


    // Update is called once per frame
    void FixedUpdate()
    {
        aimDirection = Vector3.RotateTowards(aimDirection, aimInput, Time.fixedDeltaTime * stats.aimSpeed, 1);
        
        
        //mainGun.transform.rotation = Quaternion.Euler(aimDirection.x, aimDirection.y, 0);
        mainGun.transform.right = aimDirection - new Vector2(mainGun.transform.position.x, mainGun.transform.position.y) ;

        mainGun.transform.eulerAngles = new Vector3(mainGun.transform.eulerAngles.x, mainGun.transform.eulerAngles.y, mainGun.transform.eulerAngles.z - 90);

    }
}
