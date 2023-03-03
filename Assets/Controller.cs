using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    BoxCollider2D boxCollider2D;

    [SerializeField] float moveSpeed = 1;
   

    


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            transform.position += new Vector3(0,moveSpeed);
        }
        if(Input.GetKey(KeyCode.S)){
            transform.position -= new Vector3(0,moveSpeed);
        }
        if(Input.GetKey(KeyCode.A)){
            transform.position -= new Vector3(moveSpeed,0);
        }
        if(Input.GetKey(KeyCode.D)){
            transform.position += new Vector3(moveSpeed,0);
        }
    }   
}
