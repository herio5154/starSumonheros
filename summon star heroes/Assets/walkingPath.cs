using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkingPath : MonoBehaviour {
    public bool finshed;
    public bool walking;
    public Transform pathholder;
    public List<pathinformation> pathInfio = new List<pathinformation>();
    public float speed;
    public Rigidbody2D Npcbody;
    public Animator Iswalking;
    public movement walkDirection;
    private float walkingX;
    private float walkingY;
    public int walkID;
 
    void OnDrawGizmos()
    {
         Vector3 startPositoin = pathholder.GetChild(0).position;
         Vector3 Lastposition = startPositoin;
        foreach (Transform waypoint in pathholder)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(Lastposition, waypoint.position);
            Lastposition = waypoint.position;
        }


    }
    void Start()
    {
 

    }

    // Update is called once per frame
    void Update () {
        Iswalking.SetBool("walking", walking);
     
        if (walking == true)
            if (Vector3.Distance(transform.position, pathInfio[walkID].location.position) > 0.1f)
            {
                walking = false;
            }

        {
            Iswalking.SetFloat("Horizontal", walkingX);
            Iswalking.SetFloat("Vertical", walkingY);
             walkDirection = pathInfio[walkID].walkDirection;
      
                if (walkDirection == movement.up)
            {
                Npcbody.velocity = new Vector2(0, speed);
                walkingY = 1;
                walkingX = 0;
            }
            if (walkDirection == movement.right)
            {
                Npcbody.velocity = new Vector2(speed, 0);
                walkingY = 0;
                walkingX = 1;
            }
            if (walkDirection == movement.down)
            {
                Npcbody.velocity = new Vector2(0, -speed);
                walkingX = 0;
                walkingY = -1;
            }

            if (walkDirection == movement.left)
            {
                Npcbody.velocity = new Vector2(-speed, 0);
                walkingY = 0;
                walkingX = -1;
            }

        }
        if(walking == false)
        {
            Npcbody.velocity = new Vector2(0,0);

        }
    }
    
}
