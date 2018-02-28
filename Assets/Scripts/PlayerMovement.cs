using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float speed = 4;

    [SerializeField]
    private float jumpHeight = 50;

    [SerializeField]
    private Rigidbody2D rb;

	[SerializeField]
	private float passPoint = 42.25f;

	[SerializeField]
	private GameObject eogCanvas;

    private float MIN_HEIGHT = -5;
    private bool ableToJump;
    private int life;

	private bool checkLvl = true;
	private bool play = true;
    public List<Vector3> checkPoints;
    private Vector3 respawn;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        if (tag == "Platform")
        {
            ableToJump = true;
        }

		if (tag == "RedGem") {
			DB.Database.AddScore (20);
			Destroy (collision.gameObject);
		} else if (tag == "YellowGem") {
			DB.Database.AddScore (50);
			Destroy (collision.gameObject);
		} else if (tag == "BlueGem") {
			DB.Database.AddScore (100);
			Destroy (collision.gameObject);
		} else if (tag == "OrangeGem") {
			DB.Database.AddScore (200);
			Destroy (collision.gameObject);
		} else if (tag == "GreyGem") 
		{
			DB.Database.AddScore (500);
			Destroy (collision.gameObject);
		}
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            ableToJump = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
		if (play) {
			float x = Input.GetAxis ("Horizontal");
			transform.position += Vector3.right * x * speed * Time.deltaTime;

			if (Input.GetKeyDown ("space") && ableToJump)
				Jump ();

			//find checkpoint
			CheckPoint ();
		}
        if (transform.position.y <= MIN_HEIGHT)
        {
            DB.Database.RemoveLife();
            life = DB.Database.getLife();
            if (life == 0)
				ShowEOG();
			
            transform.position = respawn;
        }

		if(checkLvl)
		LevelCheck();
    }

	private void LevelCheck(){
		if (transform.position.x >= passPoint)
		{
			int lvl = DB.Database.NextLevel();
			if (lvl != -1)
				Application.LoadLevel (lvl);
			else
				ShowEOG();
		}
	}

	/// <summary>
	/// Activate end of game canvas stopping level checking and playing functions
	/// </summary>
	private void ShowEOG(){
		checkLvl = false; // to not check lvl after this frame
		play = false;
		eogCanvas.active = true;
	}

    /// <summary>
    /// Checks the point.
    /// </summary>
    private void CheckPoint()
    {
        float xPos = transform.position.x;
        if (checkPoints.Count > 1)
            for (int i = 1; i < checkPoints.Count; i++)
            {
                if (xPos > checkPoints[i].x)
                {
                    checkPoints.RemoveAt(0);
                    i--;
                    break;
                }
            }
        if (checkPoints.Count > 0)
            respawn = checkPoints[0];
    }

    /// <summary>
    /// jump function
    /// </summary>
    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpHeight);
    }
}
