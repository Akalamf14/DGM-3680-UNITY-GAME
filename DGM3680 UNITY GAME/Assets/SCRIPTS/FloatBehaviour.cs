using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloatBehaviour : MonoBehaviour
{
    public float value = 1f;

    public UnityEvent collisionEnterEvent, atZeroEvent;


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Bullet")
        {
            Debug.Log("Object Collided");
            collisionEnterEvent.Invoke();

        }
        
    }

    public void UpdateValue(float number)
    {
        value += number;

        if(value <= 0)
        {
            atZeroEvent.Invoke();
            //Destroy(gameObject);
        }
       
    }

     
}

