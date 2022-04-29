using System;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class SwipeManager : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
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

    protected virtual void SwipeUp()
    {

    }

    protected virtual void SwipeDown()
    {

    }

    protected virtual void SwipeRight()
    {

    }

    protected virtual void SwipeLeft()
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
    }
}
