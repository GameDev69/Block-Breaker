using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip breakSound;

    // cached refs
    Level level;
    GameSession gameStatus;

    int count;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.countBreakableBlocks();
        gameStatus = FindObjectOfType<GameSession>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y));
        Destroy(gameObject);
        gameStatus.addToScore();
        level.BlockDestroyed();
    }
}
