using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject breakVFX;
    [SerializeField] int maxHits;
    [SerializeField] int timesHit;
    [SerializeField] Sprite[] hitSprites;
    //cached references
    Level level;
    GameStatus gameStatus;
    private void Awake()
    {  
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void Start()
    {
        if(tag == "Breakable")
        {
            level.CountBreakableBlocks();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleHit();
    }

    private void HandleHit()
    {
        timesHit++;
        maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
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
        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError( $"Sprites is missing from Array - {gameObject.name}");
        }
    }

    private void DestroyBlock()
    {
        if (tag == "Breakable")
        {
            AudioSource.PlayClipAtPoint(breakSound, transform.position);
            level.DestroyBlock();
            gameStatus.AddToScore();
            SparklesEffect();
            Destroy(gameObject);
        }
    }

    private void SparklesEffect()
    {
        GameObject sparkles = Instantiate(breakVFX, transform.position, Quaternion.identity);
        Destroy(sparkles, 1.5f);
    }
}
