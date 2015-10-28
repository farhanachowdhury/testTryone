/*Created by: Farhana Chowdhury
 Student ID: 300812011
 Source: Comp-305 Professor's uploadded video, Unity 2D Platform Tutorial Video.
 This class was built to provide the methods for Player's Contorll  */
using UnityEngine;
using System.Collections;
//velocity range utility class
[System .Serializable]
public class VelocityRange
{
    // public instance variable
    public float vMin, vMax;
    
    //constructor
    public VelocityRange(float vMin, float vMax)
    {
        this.vMax = vMax;
        this.vMin = vMin;
    }

}
public class PlayerController : MonoBehaviour {
    //public instance variables-----------
    public float speed = 50f;
    public float jump = 1500f;
    public VelocityRange velocityRange = new VelocityRange  (300f, 1000f);
    public int life = 3;
   /* public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;*/

    // private instance variables
    private Rigidbody2D _rigidBody2D;
    private Transform _transform;
    private Animator _animator;// for later use-----

    private AudioSource[] _audioSource;
    private AudioSource _coinSound;
    private AudioSource _jumpSound;

    private float _movingValue = 0;
    private bool _isFacingRight = true;
    private bool _isGrounded = true;

	// Use this for initialization
	void Start () {
        this._rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        this._transform = gameObject.GetComponent<Transform>();
        this._animator = gameObject.GetComponent<Animator>();


        this._audioSource = gameObject.GetComponents<AudioSource>();
        this._coinSound = this._audioSource[0];
        this._jumpSound = this._audioSource[1];
	    

	}
	
	// Update is called once per frame
   /* void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }*/
	void FixedUpdate () 
    {
        float forceX = 0f;
        float forceY = 0f;

        float absVelX = Mathf.Abs(this._rigidBody2D.velocity.x);
        float absVelY = Mathf.Abs(this._rigidBody2D.velocity.y);

        this._movingValue = Input.GetAxis("Horizontal"); // value is between -1 and +1

       //check if player is moving
        if (this._movingValue != 0)
        {
            //we are moving
            this._animator.SetInteger("AnimState", 1);//play run clip
            if (this._movingValue > 0)
            {
                //moving right
                if(absVelX <this.velocityRange.vMax )
                {
                    forceX = this.speed;
                    this._isFacingRight = true;
                    this._flip();
                }
            }
            else if (this._movingValue < 0)
            {
                //moving left
                if (absVelX < this.velocityRange.vMax)
                {
                    forceX = -this.speed;
                    this._isFacingRight = false;
                    this._flip();
                }
            }
        } else if(this._movingValue  == 0)
        {
            //we are idle
            this._animator.SetInteger("AnimState", 0);//play idle clip
        }
        //check if player is jumping

        if(Input.GetKey("up") || Input.GetKey(KeyCode.W))
        {
            //check if the player is grounded
            if(this._isGrounded)
            {
                //player is jumping
                this._animator.SetInteger("AnimState", 2);//play jump clip
                if (absVelY < this.velocityRange.vMax)
                {
                    forceY = this.jump;
                    this._jumpSound.Play();
                    this._isGrounded = false;
                }

            }
            
        }

        this._rigidBody2D.AddForce(new Vector2(forceX, forceY));
        
	}
    void OnCollisionEnter2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Coin"))
        {
            this._coinSound.Play ();
        }

        if (otherCollider.gameObject.CompareTag("Enemy"))
        {
            //decreasing life count of the player 
            life = life-1;
           if(this.life == 0)
            {
                Destroy(gameObject);

            }
       
        }
    }
    void OnCollisionStay2D(Collision2D otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Platform"))
        {
            this._isGrounded = true;
        }
    }
    

    //private methods-----------
    private void _flip()
    {
        if (this._isFacingRight )
        {
            this._transform.localScale = new Vector3(1f, 1f, 1f);//flip back to right
        }
        else
        {
            this._transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
    private void ThunderShooting()
    {
        if (Input.GetKey("space") || Input.GetMouseButton(0)) 
        {
        
        }

    }
}
