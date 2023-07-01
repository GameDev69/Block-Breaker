using UnityEngine;

public class Paddle : MonoBehaviour
{

    #region configuration parameters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] private float padding = 0.5f;
    #endregion
    
    #region cached refs
    GameSession _gameSession;
    Ball _ball;
    private float _xMin;
    private float _xMax;
    private float _yMin;
    private float _yMax;
    Camera _gameCamera;

    #endregion

    private void Start()
    {
        _gameSession = FindObjectOfType<GameSession>();
        _ball = FindObjectOfType<Ball>();
        SetUpMoveBoundaries();
        _gameCamera = Camera.main;
    }

    private void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), _xMin, _xMax);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        
        if (_gameSession.IsAutoPlaEnabled())
        {
            return _ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
    
    private void SetUpMoveBoundaries()
    {
        _xMin = _gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        _xMax = _gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }
}
