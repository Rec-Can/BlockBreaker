using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks; //Debug purposes
    //cached references
    SceneLoader sceneLoader;
    private void Awake()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void DestroyBlock()
    {
        breakableBlocks--;
        if(breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
