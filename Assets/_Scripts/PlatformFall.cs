/*Created by: Farhana Chowdhury
 Student ID: 300812011
 Source: Comp-305 Professor's uploadded video, Unity 2D Platform Tutorial Video.
 This class was built to provide the methods for Platform fall  */
using UnityEngine;
using System.Collections;

public class PlatformFall : MonoBehaviour {

    public float fallDelay = 1f;

    private Rigidbody2D rb2d;

    // Use this for initialization
	void Awake () 
    {
        rb2d = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D  other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay);
        }
    }
    void Fall()
    {
        rb2d.isKinematic = false;
    }
}
