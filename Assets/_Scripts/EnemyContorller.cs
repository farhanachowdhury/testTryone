/*Created by: Farhana Chowdhury
 Student ID: 300812011
 Source: Comp-305 Professor's uploadded video, Unity 2D Platform Tutorial Video.
 This class was built to provide the methods for enemy Contorll  */
using UnityEngine;
using System.Collections;

public class EnemyContorller : MonoBehaviour {
    public float speed = 0;

    private Rigidbody2D _rigidBody2D;
    private Transform _transform;
    private Animator _animator;

    private bool _isGrounded = false;

	// Use this for initialization
	void Start () {
        this._rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        this._transform = gameObject.GetComponent<Transform>();
        this._animator = gameObject.GetComponent<Animator>();
	
	}
    
	
	// Update is called once per frame
	void FixedUpdate () {
        //check if enemy is grounded
        if (this._isGrounded)
        {
            this._animator.SetInteger("Animator", 0);
        }
	
	}
    void OnCollisionStay2D (Collision2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Platform"))
        {
            this._isGrounded = true;
        }
    }
    void OnCollisionEnter2D(Collision2D otherCollider)
    {
       
        if (otherCollider.gameObject.CompareTag("Thunder"))
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionExit2D(Collision2D otherCollider)
    {
        if (otherCollider .gameObject .CompareTag ("Platform"))
        {
            this._isGrounded = false;
        }
    }
}
