using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    #region params
    [SerializeField] int breakableBlocks; // serialized for debaggung
    #endregion

    #region cached refs
    SceneLoader _sceneLoader;
    #endregion


    private void Start()
    {
        _sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if(breakableBlocks <= 0)
        {
            _sceneLoader.LoadNextScene();
        }
    }
}
