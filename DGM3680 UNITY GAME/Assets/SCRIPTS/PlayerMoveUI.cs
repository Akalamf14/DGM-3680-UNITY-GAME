using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveUI : MonoBehaviour
{
    Vector3 up = Vector3.zero,
    right = new Vector3(0, 90, 0),
    down = new Vector3(0, 180, 0),
    left = new Vector3(0, 270, 0),
    currentDirection = Vector3.zero;
    
    Vector3 nextPos, destination, direction;
    
    float speed = 5f;
    float rayLength = 1f;
    public int jump;
    bool canMove;

   void Start()
   {
       currentDirection = up;
       nextPos = Vector3.forward;
       destination = transform.position;
    
   }

   public void MoveForward()
   {
       transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        nextPos = Vector3.forward;
        currentDirection = up;
        canMove = true;
       

       if(Vector3.Distance(destination, transform.position) <= 0.0000f)
       {
           transform.localEulerAngles = currentDirection;
           if(canMove)
           {
               if(Valid())
               {
                   destination = transform.position + nextPos;
                   direction = nextPos;
                   canMove = false;
                }
            }
        }
   }

   public void MoveBackward()
   {
       transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        nextPos = Vector3.back;
        currentDirection = down;
        canMove = true;


       if(Vector3.Distance(destination, transform.position) <= 0.0000f)
       {
           transform.localEulerAngles = currentDirection;
           if(canMove)
           {
               if(Valid())
               {
                   destination = transform.position + nextPos;
                   direction = nextPos;
                   canMove = false;
                }
            }
        }
    }

    public void MoveLeft()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        nextPos = Vector3.left;
        currentDirection = left;
        canMove = true;


       if(Vector3.Distance(destination, transform.position) <= 0.0000f)
       {
           transform.localEulerAngles = currentDirection;
           if(canMove)
           {
               if(Valid())
               {
                   destination = transform.position + nextPos;
                   direction = nextPos;
                   canMove = false;
                }
            }
        }
    }

    public void MoveRight()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        nextPos = Vector3.right;
        currentDirection = right;
        canMove = true;

       if(Vector3.Distance(destination, transform.position) <= 0.0000f)
       {
           transform.localEulerAngles = currentDirection;
           if(canMove)
           {
               if(Valid())
               {
                   destination = transform.position + nextPos;
                   direction = nextPos;
                   canMove = false;
                }
            }
        }
    }

    bool Valid()
   {
       Ray myRay = new Ray(transform.position + new Vector3(0, 0.25f, 0), transform.forward);
       RaycastHit hit;

       Debug.DrawRay(myRay.origin, myRay.direction, Color.red);

       if(Physics.Raycast(myRay, out hit, rayLength))
       {
           if(hit.collider.tag == "wall")
           {
               return false;
           }
       }
       return true;
   }
   
}
