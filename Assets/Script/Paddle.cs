using UnityEngine;

public class Paddle : MonoBehaviour
{

    #region configuration parameters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] private float padding = 0.5f;
    #endregion
    
    #region cached refs
    GameSession findObjectOfType;
    Ball objectOfType;
    private float _xMin;
    private float _xMax;
    private float _yMin;
    private float _yMax;
    Camera gameCamera;

    #endregion

    void Start()
    {
        findObjectOfType = FindObjectOfType<GameSession>();
        objectOfType = FindObjectOfType<Ball>();
        SetUpMoveBoundaries();
        gameCamera = Camera.main;
    }

    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), _xMin, _xMax);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        
        if (findObjectOfType.IsAutoPlaEnabled())
        {
            return objectOfType.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
    
    private void SetUpMoveBoundaries()
    {
        _xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        _xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }
}
