using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("countdown").GetComponent<CanvasRenderer>().SetColor(new Color(0, 0, 0, 0));    
        update_life();
        Vector2 brick_proto_position= GameObject.Find("brick_proto").transform.position;
        float brick_proto_position_x = brick_proto_position.x;
        float brick_proto_position_y = brick_proto_position.y;

        for (int j = 0; j < 6; j++)
        {

           

            for (int i = 0; i < 8; i++)
            {
                Random rnd = new Random();
                
                GameObject brick= Instantiate(GameObject.Find("brick_proto"), new Vector3(brick_proto_position_x + i * 2, brick_proto_position_y -j*0.7f, 0), Quaternion.identity);
                brick.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                brick.tag = "brick_tag";
                GlobalVariables.bricks_left++;
 //               life_script.update_bricks();
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalVariables.life < 1) {
            GlobalVariables.life = 10;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
    }

    public static void update_life() {
        GameObject.Find("life_text").GetComponent<UnityEngine.UI.Text>().text = GlobalVariables.life.ToString();
    }

    public static void update_bricks()
    {
        // getCount = GameObject.FindGameObjectsWithTag("pickup");
        // GameObject.Find("br_count").GetComponent<UnityEngine.UI.Text>().text = GlobalVariables.bricks_left.ToString();
        int bricks_leftint = GameObject.FindGameObjectsWithTag("brick_tag").Length;
        GameObject.Find("br_count").GetComponent<UnityEngine.UI.Text>().text = bricks_leftint.ToString();
        if (bricks_leftint<2)        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }

        //" FindGameObjectsWithTag("br_proto");
    }


    


}


