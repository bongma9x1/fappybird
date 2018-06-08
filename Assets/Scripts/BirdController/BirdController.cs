using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {

    public static BirdController instance;

    public float bouncrForce;

    private Rigidbody2D myBody;
    private Animator anim;
    // audio
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip flyClip, pingClip, diedClip;

    private bool isAlive;
    private bool didFlap;

    public float flag = 0;
    public int Score = 0;
	void Awake () {
        isAlive = true;
		myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _MakeInstance();
	}
    void _MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
	// Update is called once per frame
	void FixedUpdate () {
        _BirdMoveMent();
	}

    void _BirdMoveMent()
    {
        if(isAlive == true)
        {
            if(didFlap)
            {
                didFlap = false;
                myBody.velocity = new Vector2(myBody.velocity.x, bouncrForce);
                audioSource.PlayOneShot(flyClip);
            }
        }

        if (myBody.velocity.y > 0)
        {
            float angel = 0;
            angel = Mathf.Lerp(0, 90, myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
        else if (myBody.velocity.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            float angel = 0;
            angel = Mathf.Lerp(0, -90, -myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
    }

    public void _FlapButton()
    {
        didFlap = true;
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Pipeholder")
        {
            audioSource.PlayOneShot(pingClip);
            Score++;
            if(GamePlayControl.instance != null)
            {
                GamePlayControl.instance._setScore(Score);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Pipe" || target.gameObject.tag == "Groud")
        {
            flag = 1;
            if (isAlive) 
            { 
                isAlive = false;
                audioSource.PlayOneShot(diedClip);
                anim.SetTrigger("Died");
            }
            if (GamePlayControl.instance != null)
            {
                GamePlayControl.instance._banerOver(Score);
            }
        }
    }
}
