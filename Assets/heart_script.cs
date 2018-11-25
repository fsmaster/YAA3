using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 heart_position = gameObject.transform.position;
        float heart_position_y = heart_position.y;
        Debug.Log(heart_position.y);
        if (heart_position_y<-3)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        } else
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "bat")
        {

            Debug.Log(gameObject.name);
            if (gameObject.name == "heart_sprite")
            {
                GlobalVariables.life++;
                life_script.update_life();
            }
            //else 
            if (gameObject.name == "3_balls_copy")
            {
                Debug.Log(gameObject.name);
                Vector2 pos = GameObject.Find("ball").transform.position;
                float pos_x = pos.x;
                float pos_y = pos.y;

                for (int i = 0; i < 3; i++)
                {
                    GameObject ball_copy = Instantiate(GameObject.Find("ball"), new Vector3(pos_x - 0.01f, pos_y+0.2f, 0), Quaternion.identity);
                    ball_copy.GetComponent<Rigidbody2D>().velocity = Vector2.up * GlobalVariables.ball_default_speed;
                    ball_copy.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 255);
                    ball_copy.name = "ball";
                }
            }

            if (gameObject.name == "wide_copy")
            {
                //   Debug.Log(gameObject.name);
                Vector3 cursize = GameObject.Find("bat").GetComponent<RectTransform>().transform.localScale;
                //               StartCoroutine(StartCountdown3(cursize.ToString()));
           //     GameObject.Find("alert").GetComponent<UnityEngine.UI.Text>().text = "Wide bat";
                GameObject.Find("bat").GetComponent<RectTransform>().transform.localScale = new Vector3(5f,0.5f,0);
          
            }
                Destroy(gameObject);
        }
        if (col.gameObject.name=="bottom_line") { Destroy(gameObject); }
        
    }


    public static IEnumerator StartCountdown3(string message)
    {
        GameObject.Find("alert").GetComponent<UnityEngine.UI.Text>().text = message;
        float currCountdownValue = 1f;
        while (currCountdownValue >= 0)
        {
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
        GameObject.Find("alert").GetComponent<UnityEngine.UI.Text>().text = " ";
        GameObject.Find("alert").GetComponent<CanvasRenderer>().SetColor(new Color(0, 0, 0, 0));

    }



}
