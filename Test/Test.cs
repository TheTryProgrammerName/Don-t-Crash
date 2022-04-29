using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Test : MonoBehaviour
{
    /*public CharacterControl CharacterControl;

    public Rigidbody2D rbd;

    public Rigidbody2D postRB1, postRB2;

    public TextMeshProUGUI tgrf, tgrf2, tgrf3;

    private bool touch;

    public void Start()
    {
        rbd.gameObject.GetComponent<Character>().Immortality = true;
    }

    public void FixedUpdate()
    {
        if (postRB1.position.x <= -9 & postRB1.position.x > -10 & touch)
        {
            if (rbd.position.y < 0)
            {
                touch = false;
                CharacterControl.SwipeUp();
            }

            if (rbd.position.y > 0)
            {
                touch = false;
                CharacterControl.SwipeDown();
            }
        }
        if (postRB2.position.x <= -9 & postRB2.position.x > -10 & touch)
        {
            if (rbd.position.y < 0)
            {
                touch = false;
                CharacterControl.SwipeUp();
            }
            else
            {
                touch = false;
                CharacterControl.SwipeDown();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("wefrdf2es");
        touch = true;
        tgrf.text = "postRB2: " + postRB2.position.x.ToString();
        tgrf2.text = "postRB1: " + postRB1.position.x.ToString();
        tgrf3.text = "postRB2 - postRB1 :" + (postRB2.position.x - postRB1.position.x).ToString();
    }*/
}
