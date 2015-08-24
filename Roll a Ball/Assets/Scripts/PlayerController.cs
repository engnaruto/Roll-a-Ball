﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public Text countText;
	public Text winText;
	private Rigidbody rb;
	private int count;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}
	
//	// Update is called once per frame
//	void Update () {
//	
//	}

	void FixedUpdate ()
	{
		if (SystemInfo.deviceType == DeviceType.Desktop) {


			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");

			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
			rb.AddForce (movement * speed);

		
		}else{
			float moveHorizontal = Input.acceleration.x;
			float moveVertical = Input.acceleration.y;
			
			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
			rb.AddForce (movement * speed);


		}

	}

	void OnTriggerEnter (Collider other)
	{
//		Destroy(other.gameObject);
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count++;
			countText.text = "Count: " + count.ToString ();
			SetCountText ();
		}
	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			winText.text = "You Win!";
		}
	}
}
