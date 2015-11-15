using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(-42, 0, 0) * Time.deltaTime);
	}
}
