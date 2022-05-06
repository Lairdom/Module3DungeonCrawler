using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int score = 10;

    public static GameManager instance;
    
    public void AddScore(int newScore) {    //kutsu GameManager.instance.AddScore()
        score += newScore;
    }
    void Start()
    {   
        if (instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
