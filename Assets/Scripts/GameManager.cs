using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager instnace;
    public static GameManager Instance
    {
        get
        {
            return instnace;
        }
    }

    [SerializeField]
    private int score;

    private void Awake()
    {
        if (instnace == null)
        {
            instnace = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        
    }

    public void GameOver()
    {

    }
    
    public void NextLevel()
    {

    }
}
