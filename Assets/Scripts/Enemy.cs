using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Destroy(other.gameObject);
            Physics2D.gravity = new Vector3(0, -Mathf.Abs(Physics2D.gravity.y));
            Application.LoadLevel(0);
        }
    }
}
