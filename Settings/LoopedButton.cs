using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LoopedButton : Button
{
    private bool isPressed;

    public override void OnPointerEnter(PointerEventData eventData)
    {
        isPressed = true;
        StartCoroutine(LoopOnClick());
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        isPressed = false;
        StopAllCoroutines();
    }

    private IEnumerator LoopOnClick()
    {
        float timeToWait = 0.4f;

        while (isPressed)
        {
            yield return new WaitForSecondsRealtime(timeToWait);

            onClick.Invoke();

            if (timeToWait > 0.1f)
            {
                timeToWait = timeToWait - 0.05f;
            }
        }

        yield break;
    }
}
