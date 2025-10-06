using System.Diagnostics.Contracts;
using UnityEngine;

public class HelperScript : MonoBehaviour
{

    public void DoFlipObject(bool flip)
    {
        // get the SpriteRenderer component
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if (flip == true)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }


    public void HelloWorld()
    {
        if (Input.GetKeyDown("H"))
        {
            print("Hello World");
        }
           
    }

}


