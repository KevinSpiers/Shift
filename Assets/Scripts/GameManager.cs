using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject GameMenu;
    public GameObject StartMenu;

    public static GameManager instance;
 
    void Awake()
    {
        if(instance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }
    
    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this.gameObject);
	}

    void OnLevelWasLoaded(int level)
    {
        if(level == 0)
        {
            GameMenu.SetActive(false);
            StartMenu.SetActive(true);
        }
        else
        {
            GameMenu.SetActive(true);
            StartMenu.SetActive(false);
        }
    }
}
