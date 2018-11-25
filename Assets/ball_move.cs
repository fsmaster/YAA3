using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
    public static int life=10;
    public static float ball_default_speed= 5;
    public static Vector2 bat_home_position = new Vector2 (0, -4);
    public static int bricks_left = 0;



}


public class ball_move : MonoBehaviour {
    public float speed = GlobalVariables.ball_default_speed;
    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;


        GameObject paddle = GameObject.Find("bat");
        Vector2 paddlePosition = paddle.transform.position;
        Vector2 ballPosition = gameObject.transform.position;

        // this is the vector 'pointing' from the paddle to the ball
        Vector2 delta = ballPosition - paddlePosition;
        // normalizing converts a vector into a unit vector
        // (i.e. a vector with the same direction, but a magnitude of 1)
        Vector2 direction = delta.normalized;
        // set the velocity to be the direction vector scaled to the desired speed
        GetComponent<Rigidbody2D>().velocity = direction * speed;

     
    }
	
	// Update is called once per frame
	void Update () {
	//	Vector2 vel = gameObject.GetComponent<Rigidbody2D>().velocity;
    //    float vel_x = vel.x;
    //    float vel_y = vel.y;
        //if (vel_x>1) { vel_x = vel_x * 2; }
  ///     gameObject.GetComponent<Rigidbody2D>().velocity=new Vector2(vel_x,vel_y);
    }


    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketWidth)
    {
        // ascii art:
        //
        // 1  -0.5  0  0.5   1  <- x value
        // ===================  <- racket
        //
        return (ballPos.x - racketPos.x) / racketWidth;
    }




    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "bottom_line") 
          
        {
            if (gameObject.GetComponent<SpriteRenderer>().color != new Color(255, 0, 0, 255))
            {
                GlobalVariables.life--;
                // встановимо нормальний розмір
                GameObject.Find("bat").GetComponent<RectTransform>().transform.localScale = new Vector3(2f, 0.5f, 0);
                life_script.update_life();
                Vector2 home_ball_position = new Vector2(0, -3);
                GetComponent<Rigidbody2D>().MovePosition(home_ball_position);
                StartCoroutine(StartCountdown());
            }
            else
            {
                Destroy(gameObject);
            }
        } 



            // Hit the Racket?
            if (col.gameObject.name == "bat")
        {
            // Calculate hit Factor
            float x = hitFactor(transform.position,
                              col.transform.position,
                              col.collider.bounds.size.x);

            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }



    float currCountdownValue;
    public IEnumerator StartCountdown(float countdownValue = 3)
    {
        GameObject.Find("bat").GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GameObject.Find("bat").GetComponent<Rigidbody2D>().MovePosition(GlobalVariables.bat_home_position);
        currCountdownValue = countdownValue;
        GameObject.Find("countdown").GetComponent<CanvasRenderer>().SetColor(new Color(255,0,0,255)); 
        while (currCountdownValue >= 0)
        {
           GameObject.Find("countdown").GetComponent<UnityEngine.UI.Text>().text = currCountdownValue.ToString();
           Debug.Log("Countdown: " + currCountdownValue);
           yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, GlobalVariables.ball_default_speed);
        GameObject.Find("countdown").GetComponent<CanvasRenderer>().SetColor(new Color(0, 0, 0, 0));
    }



}


