using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        
        {

        }

    }
    public void BREAK2 ()
    {
        bc.enabled = !bc.enabled;
        if (this.GetComponent<MeshRenderer>().material.color == new Color(1.0f, 1.0f, 1.0f, 1.0f))
        {
            this.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
        }
        else this.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        {

        }

        {

        }


    }
}

    // Update is called once per frame
  