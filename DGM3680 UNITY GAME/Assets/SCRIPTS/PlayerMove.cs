using UnityEngine;

public class PlayerMove : MonoBehaviour
{
   Vector3 up = Vector3.zero, right = new Vector3(0, 90, 0), down = new Vector3(0, 180, 0), left = new Vector3(0, 270, 0), currentDirection = Vector3.zero;
   Vector3 nextPos, destination, direction;

   float speed = 5f;
   float rayLength = 1f;
   public int jump;
   bool isGrounded;
   bool canMove;

   void Start()
   {
       currentDirection = up;
       nextPos = Vector3.forward;
       destination = transform.position;
    
   }

   void OnCollisionStay()
   {
       isGrounded = true;
   }

   void Update()
   {
       if(isGrounded)
       {
           Move();
       }    
    }

   public void Move()
   {
       transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

       if(Input.GetKeyDown(KeyCode.W))
       {
           nextPos = Vector3.forward;
           currentDirection = up;
           canMove = true;
       }

       if(Input.GetKeyDown(KeyCode.S))
       {
           nextPos = Vector3.back;
           currentDirection = down;
           canMove = true;
       }

       if(Input.GetKeyDown(KeyCode.D))
       {
           nextPos = Vector3.right;
           currentDirection = right;
           canMove = true;
       }

       if(Input.GetKeyDown(KeyCode.A))
       {
           nextPos = Vector3.left;
           currentDirection = left;
           canMove = true;
       }
    
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

        if(Input.GetKeyDown(KeyCode.Space) && currentDirection == up)
        {
            nextPos = Vector3.forward * jump;
            currentDirection = up;
            canMove = true;
        }

          if(Input.GetKeyDown(KeyCode.Space) && currentDirection == down)
        {
            nextPos = Vector3.back * jump;
            currentDirection = down;
            canMove = true;
        }

          if(Input.GetKeyDown(KeyCode.Space) && currentDirection == right)
        {
            nextPos = Vector3.right * jump;
            currentDirection = right;
            canMove = true;
        }

          if(Input.GetKeyDown(KeyCode.Space) && currentDirection == left)
        {
            nextPos = Vector3.left * jump;
            currentDirection = left;
            canMove = true;
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
