using UnityEngine;
using System.Collections;
public enum  movement { NA,up, right, down, left  }
public class npcmovement : MonoBehaviour {
    public float npcSpeed;
    public movement walkDirection;
    public bool isWalking;
    public bool lookingD;
    public bool faceingPlayer;
    private float walkingX;
    private float walkingY;
    public npcFaceing npc;
    public Rigidbody2D NPC;
    public Animator walking;

    // Use this for initialization
    void Start () {
        NPC = GetComponent<Rigidbody2D>();
        walking = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update () {
        walking.SetFloat("Horizontal", walkingX);
        walking.SetFloat("Vertical", walkingY);
        {
            lookingD = false;
             choseDIreactuion();
            walking.SetBool("walking", true);             
        }
    if (isWalking == false)
            {
            NPC.velocity = Vector2.zero;
            walking.SetBool("walking", false);
            if (faceingPlayer == true)
            {
                lookingD = false;
                npc.wachingPlayer = true;
            }
                if (lookingD == true)
            {
                faceingPlayer = false;
                looking();
            }

        }


    }
    public void choseDIreactuion()
    {
     if(walkDirection == movement.up)
        {
            NPC.velocity = new Vector2(0, npcSpeed);
            walkingY = 1;
            walkingX = 0;
        }
        if (walkDirection == movement.right)
        {
            NPC.velocity = new Vector2(npcSpeed, 0);
            walkingY = 0;
            walkingX = 1;
        }
        if (walkDirection == movement.down)
        {
            NPC.velocity = new Vector2(0, -npcSpeed);
            walkingX = 0;
            walkingY = -1;
        }

        if (walkDirection == movement.left)
        {
            NPC.velocity = new Vector2(-npcSpeed, 0);
            walkingY = 0;
            walkingX = -1;
        }
  
      
    }
    public void looking()
    {
        if (walkDirection == movement.up)
        {
            walkingY = 1;
            walkingX = 0;
        }
        if (walkDirection == movement.right)
        {
            walkingY = 0;
            walkingX = 1;
        }
        if (walkDirection == movement.down)
        {
            walkingX = 0;
            walkingY = -1;
        }

        if (walkDirection == movement.left)
        {
            walkingY = 0;
            walkingX = -1;
        }
    }
}


