using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GemTracker : MonoBehaviour
{
    public static GemTracker instance;

    

    private int gemsCount;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }  
    }

    // Start is called before the first frame update
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            gemsCount = 0;
        }
    }

    public void AddGems(int gems)
    {
        gemsCount = gems;
    }

    public int GemsCount()
    {
        return gemsCount;
    }
}
