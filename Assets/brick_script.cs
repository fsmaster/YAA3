using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick_script : MonoBehaviour {



    void Start()

    {
      
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "ball") 
        {
            int rnd = Mathf.RoundToInt(Random.Range(0f, 20f));
            Vector2 pos = gameObject.transform.position;
            float pos_x = pos.x;
            float pos_y = pos.y;



            // Debug.Log(rnd);


            Destroy(gameObject);
           
            if (rnd == 3)
            {

               GameObject heart_copy= Instantiate(GameObject.Find("heart_sprite"), new Vector3(pos_x, pos_y, 0), Quaternion.identity);
                heart_copy.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
                heart_copy.name = "heart_sprite";
            }

           if (rnd==4)
            {

                GameObject ball_copy = Instantiate(GameObject.Find("3_balls"), new Vector3(pos_x, pos_y, 0), Quaternion.identity);
                ball_copy.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
                //Vector2 tmpvec = ball_copy.transform.position;
                //float tmpx = tmpvec.x;
                //float tmpy = tmpvec.y;
                //ball_copy.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -3);
                ball_copy.name = "3_balls_copy";
            }

            if (rnd == 5)
            {

                GameObject wide_copy = Instantiate(GameObject.Find("wide_proto"), new Vector3(pos_x, pos_y, 0), Quaternion.identity);
                wide_copy.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
                wide_copy.name = "wide_copy";
            }

 //           GlobalVariables.bricks_left--;
        //    life_script.update_bricks();

        }
    }

    

    // Update is called once per frame
    void Update () {
        life_script.update_bricks();

    }
}
