using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MovementChar {

    private Camera cam;
    private Ray raio;

    private Vector3 positionTarget;
    
    
    void Start(){
  	    cam = GameObject.FindObjectOfType<Camera>();
        
    }
    
    public void RotationPlayer(LayerMask floorMask)
    {
      raio = cam.ScreenPointToRay(Input.mousePosition);
      Debug.DrawRay(raio.origin,raio.direction,Color.red);
      RaycastHit impact;
      if (Physics.Raycast(raio,out impact,50,floorMask)){
        positionTarget = impact.point - transform.position;
        positionTarget.y = transform.position.y;
        RotationChar(positionTarget);
      }
    }

}
