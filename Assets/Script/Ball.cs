using UnityEngine;

public class Ball : MonoBehaviour
{
    #region config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] private float randomFactor = 0.2f;
    #endregion

    #region state
    Vector2 _paddleToBallVector;
    bool _hasStarted = false;
    #endregion

    #region Cached component references
    private AudioSource _myAudioSource;
    private Rigidbody2D _myRigidbody2D;
    #endregion

    void Start()
    {
        _paddleToBallVector = transform.position - paddle1.transform.position;
        _myAudioSource = GetComponent<AudioSource>();
        _myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(!_hasStarted)
        {
            lockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

   private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _hasStarted = true;
            _myRigidbody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void lockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = _paddleToBallVector + paddlePos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(
            Random.Range(0, randomFactor), 
            Random.Range(0, randomFactor));
        if(_hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            _myAudioSource.PlayOneShot(clip);
            _myRigidbody2D.velocity += velocityTweak;
        }
    }
}
