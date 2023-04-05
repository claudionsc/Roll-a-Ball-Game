using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;


    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        winText.text = "";
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

         rb.AddForce (movement * speed);
          if(Input.GetKeyDown(KeyCode.RightAlt))
        {
            rb.AddForce (movement * (speed * 100));
        } 

        Break();
        // Turbo(movement);
    }

    void Break()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.drag = 8;
        } 
        else {
            rb.drag = 0;
        }
    }

    // void Turbo(Vector3 movement)
    // {
    //       if(Input.GetKeyDown(KeyCode.RightAlt))
    //     {
    //         rb.AddForce (movement * (speed * 100));
    //         speed = 50;
    //     } 
    //     // else {
    //     //     rb.drag = 0;
    //     // }
    // }

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