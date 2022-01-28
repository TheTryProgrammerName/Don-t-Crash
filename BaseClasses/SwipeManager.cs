using System;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class SwipeManager : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public bool lockControl;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!lockControl)
        {
            if (Math.Abs(eventData.delta.y) > Math.Abs(eventData.delta.x))
            {
                if (eventData.delta.y > 0)
                {
                    SwipeUp();
                }
                else
                {
                    SwipeDown();
                }
            }
            else
            {
                if (eventData.delta.x > 0)
                {
                    SwipeRight();
                }
                else
                {
                    SwipeLeft();
                }
            }
        }
    }

    public virtual void SwipeUp()
    {

    }

    public virtual void SwipeDown()
    {

    }

    public virtual void SwipeRight()
    {

    }

    public virtual void SwipeLeft()
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
    }
}
