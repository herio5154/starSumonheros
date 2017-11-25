using UnityEngine;
using System.Collections;

public class walk : MonoBehaviour {
    public float LocationX;
    public float LocationY;
    public Animator kid;
    public float Speed;
    public movement walkDirection;
    public bool cutseen;
    public float walkingX;
    public float walkingY;
    public bool walking;
    public bool notMoveing;


     // Use this for initialization
    void Start () {
         kid = GetComponent<Animator>();
        walking = true;
    }

    // Update is called once per frame
    void Update()
    {

        LocationX = gameObject.transform.position.x;
        LocationY = gameObject.transform.position.y;

        if (cutseen == false)
        {
 
            if (walking == true)
            {

                kebord();
                kid.SetBool("iswalking", true);
            }

            if (walking == false)
            {
                kid.SetBool("iswalking", false);
            }

        }
        if(cutseen == true)
        {
            numbers();

             if (walking == true)
            {
                kid.SetBool("iscutseen", false);
                kid.SetBool("iswalking", true);
                cutSeeen();

            }
            if (walking == false)
            {
                kid.SetBool("iscutseen", true);
                kid.SetBool("iswalking", false);
                cutSeeen();
            }

        }



    }
    public void numbers()
    {
        kid.SetBool("iscutseen", false);
        kid.SetBool("iswalking", true);
        Vector2 moveDirection;
        moveDirection.x = walkingX;
        moveDirection.y = walkingY;
        kid.SetFloat("Horizontal", moveDirection.x);
        kid.SetFloat("Vertical", moveDirection.y);

    }
    public void playerstop()
    {
        walking = false;
        cutseen = true;
        notMoveing = true;
     }
    public void playerpause()
    {
        walking = false;
        notMoveing = true;
    }

    public void playergo()
    {
        walking = true;
        cutseen = false;
        notMoveing = false;

    }
    public void walkbehind()
    {
        walking = true;
        cutseen = true;
     }
    public void cutSeeen()
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
    public void kebord()
    {
        Vector2 moveDirection;
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.y = Input.GetAxis("Vertical");
        transform.Translate(moveDirection * Speed * Time.deltaTime);
         kid.SetFloat("Horizontal", moveDirection.x);
        kid.SetFloat("Vertical", moveDirection.y);

    }

}
    

