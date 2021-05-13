using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    [SerializeField] AudioClip[] ballAudioClips;
    [SerializeField] float randomFactor = 0.2f;
    // state variables
    Vector2 paddleToBallVector;
    bool hasStarted = false;
    // cached references
    Rigidbody2D rigidBody;
    AudioSource ballAudio;
    // Start is called before the first frame update
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        ballAudio = GetComponent<AudioSource>();
    }
    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        LockBallToPaddle();
        LaunchBallOnClick();
    }

    private void LockBallToPaddle()
    {
        if (!hasStarted)
        {
            Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
            transform.position = paddlePos + paddleToBallVector;
        }
    }

    private void LaunchBallOnClick()
    {
        if (Input.GetMouseButtonDown(0) && !hasStarted)
        {
            hasStarted = true;
            rigidBody.velocity = new Vector2(5f, 15f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        float randomFactorX = Random.Range(-randomFactor, randomFactor);
        float randomFactorY = Random.Range(-randomFactor, randomFactor);
        Vector2 velocityTweak = new Vector2(randomFactorX, randomFactorY);
        if (hasStarted)
        {
            AudioClip clips = ballAudioClips[Random.Range(0, ballAudioClips.Length)];
            ballAudio.PlayOneShot(clips);
            rigidBody.velocity += velocityTweak;
        }
    }
}
