using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MovimentChar {

    private Camera cam;
    
    void Start(){
  	    Cam = GetComponent<Camera>();
    }
    
    public void RotationPlayer(LayerMask floorMask)
    {
      raio = Cam.ScreenPointToRay(Input.mousePosition);
      //Debug.DrawRay(raio.origin,raio.direction,Color.red);
      if (Physics.Raycast(raio,out impact,100,floorMask)){
        positionTarget = impact.point - transform.position;
        positionTarget.y = transform.position.y;
        Rotation(positionTarget);
      }
    }

}
