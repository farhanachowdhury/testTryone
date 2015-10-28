/*Created by: Farhana Chowdhury
 Student ID: 300812011
 Source: Comp-305 Professor's uploadded video, Unity 2D Platform Tutorial Video.
 This class was built to provide the methods for coins behaviour  */
using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag ("Player"))
        {
            Destroy(gameObject);
        }
    }
}
