using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


[CreateAssetMenu]
public class IntData : ScriptableObject
{
    public int value;

    public UnityEvent countdownEvent, setValueEvent, updateValueEvent, lessThanZeroEvent, maxValueEvent;

    public void TimerCountdown(int value)
    {
        value --;
        countdownEvent.Invoke();

    }

    public void SetValue(int number)
    {
        value = number;
        setValueEvent.Invoke();
    }

    public void UpdateValue(int number)
    {
        value += number;
        updateValueEvent.Invoke();
    }

    public void SetImageFillAmount(Image img)
    {
        if(value >= 0 || value <= 1)
        {
            img.fillAmount = value;
        }

        if(value <= 0)
        {
            lessThanZeroEvent.Invoke();
        }

        if(value >= 1)
        {
            value = 1;
        }
    }

    public void ResetValue (int number)
    {
        value = number;
    }

    public void UpdateIntPlusOne(int maxValue)
    {
        value++;
        
        if(value == maxValue)
        {
            maxValueEvent.Invoke();
        }
    }
}
