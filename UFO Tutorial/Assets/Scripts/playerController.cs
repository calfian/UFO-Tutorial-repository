﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    private Rigidbody2D rb2d;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        SetCountText();
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);

       



        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Pickup"))
        {

            other.gameObject.SetActive(false);
            count++;
            SetCountText();

        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!" + " Created by Christopher Alfian";
        }
    }

}
