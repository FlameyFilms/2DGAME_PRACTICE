using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Break BREAK;
    public GameObject Breakable;
    private Transform player;
    

    // Start is called before the first frame update
    void Start()

    {
        


        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            BREAK.BREAK2();
            

            {
                
            }
        }
    }
}


