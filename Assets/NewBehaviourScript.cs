using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
  //  public Transform brick;
    // Use this for initialization
    void Start () {
        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 5; x++)
            {
                Instantiate(this.gameObject, new Vector3(x/2, y/2, 0), Quaternion.identity);
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
