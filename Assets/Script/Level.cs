using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // params
    [SerializeField] int breakableBlocks; // serialized for debaggung

    // cached refs
    SceneLoader sceneLoader;



    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void countBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if(breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
