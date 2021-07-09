using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public SceneFader sceneFador;

    public void Select(string levelName)
    {
        Debug.Log("Go to " + levelName);
        sceneFador.ChangeScene(levelName);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
