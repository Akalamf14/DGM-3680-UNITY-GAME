using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvokeBehaviour : MonoBehaviour
{
    public UnityEvent onInvokeEvent;
    public float holdTime = 3f;
    
    
    public void OnInvoke()
    {
        Invoke(nameof(InvokeCall), holdTime);
    }

    private void InvokeCall()
    {
        onInvokeEvent.Invoke();
    }


}
