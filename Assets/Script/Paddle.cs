using UnityEngine;

public class Paddle : MonoBehaviour
{

    #region configuration parameters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    #endregion
    
    #region cached refs
    GameSession findObjectOfType;
    Ball objectOfType;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        findObjectOfType = FindObjectOfType<GameSession>();
        objectOfType = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
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
}
