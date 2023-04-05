using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text countSecText;
    public Text winText;

    private Rigidbody rb;
    private int count;
    private float countSec;


    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        countSec = 30;
        SetCountText ();
        winText.text = "";
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

         rb.AddForce (movement * speed);
        
        Break();

        if(countSec > 0)
        {
            countSec = countSec-Time.deltaTime;
            countSecText.text = $"Restam {countSec.ToString("0")} segundos!";
        }



    }

    void Break()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            rb.drag = 20;
        } 
        else {
            rb.drag = 0;
        }
    }


    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ( "Pick up"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText ();
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
        if (count >= 12)
        {
            winText.text = "You Win!!";
        }
    }


    
}