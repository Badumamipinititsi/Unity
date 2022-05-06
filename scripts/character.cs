using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
	public int Lives = 3;
    public float speed = 4.0f;
	public float jumpforce = 5.0f;
	public Rigidbody2D PlayerRigidbody;
	public Animator charAnimator;
	public SpriteRenderer sprite;
	
	void Awake()
	{
		PlayerRigidbody = GetComponentInChildren<Rigidbody2D>();
		charAnimator = GetComponentInChildren<Animator>();
		sprite = GetComponentInChildren<SpriteRenderer>();
	}
	
    void Start()
    {
        
    }


	void Move()
	{
		Vector3 tempvector = Vector3.right * Input.GetAxis("Horizontal");
		transform.position = Vector3.MoveTowards(transform.position, transform.position + tempvector, speed * Time.deltaTime);
		
		if (tempvector.x<0)
		{
			sprite.flipX = true;
		}
		else
		{
			sprite.flipX = false;
		}
	}
	
	void Jump()
	{
		PlayerRigidbody.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
	}

    void Update()
    {
        if(Input.GetButton("Horizontal"))
		{
			Move();
			charAnimator.SetInteger("State", 1);
		}

		if (Input.GetButton("Jump"))
		{
			Jump();
			charAnimator.SetInteger("State", 2);
		}
		
		if (!Input.anyKey)
		{
			charAnimator.SetInteger("State", 0);
		}

    }
}
