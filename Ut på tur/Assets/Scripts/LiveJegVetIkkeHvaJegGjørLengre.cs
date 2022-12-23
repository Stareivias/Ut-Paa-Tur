using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveJegVetIkkeHvaJegGjørLengre : MonoBehaviour
{
    public bool live = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(live == false && Input.GetKeyDown("l"))
        {
            Application.Quit();
        }
    }
}
