/*Created by: Farhana Chowdhury
 Student ID: 300812011
 Source: Comp-305 Professor's uploadded video, Unity 2D Platform Tutorial Video.
 This class was built to provide the methods for thunder Contorll  */
using UnityEngine;
using System.Collections;

public class ThunderController : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
        Rigidbody2D _rigidbidy2D = gameObject.GetComponent<Rigidbody2D>();
        //set velocity for thunder
        _rigidbidy2D.velocity = transform.right * speed;
	}
	
	// Update is called once per frame
  
}
