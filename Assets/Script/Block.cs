using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region
    [SerializeField] AudioClip breakSound;
    [SerializeField] private GameObject blockSparklesVFX;
    [SerializeField] private Sprite[] hitSprites;
    #endregion

    #region cached refs
    Level _level;
    GameSession _gameStatus;
    #endregion

    #region state vars
    [SerializeField] private int timesHit;
    

    #endregion

    int _count;

    private void Start()
    {
        CountBreakableBlocks();
        _gameStatus = FindObjectOfType<GameSession>();
    }

    private void CountBreakableBlocks()
    {
        _level = FindObjectOfType<Level>();
        if (tag.Equals("Breakable"))
        {
            _level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag.Equals("Breakable"))
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHints = hitSprites.Length + 1;
        if (timesHit >= maxHints)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextSprite();
        }
    }

    private void ShowNextSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.Log("Отсутсвует спрайт в блоке " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        // Звуковой эффект
        PlayBlockDestoySFX();
        // Уничтожение объекта
        Destroy(gameObject);
        // Увеличить счёт
        _gameStatus.addToScore();
        // Уменьшить количество блоков в статистике
        _level.BlockDestroyed();
        // Визуальный эффект
        TriggerSparklesVFX();
    }

    private void PlayBlockDestoySFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
