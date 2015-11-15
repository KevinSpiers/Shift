using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
	// Update is called once per frame
	void Update () {
        if (player)
        {
            this.gameObject.transform.position = new Vector3(player.gameObject.transform.position.x, player.gameObject.transform.position.y, -10f);
        }
	}
}
