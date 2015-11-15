using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
}
