using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    public Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f;
    private float spriteAnimationRate = 0.15f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(AnimateSprite());
    }

    private IEnumerator AnimateSprite()
    {
        while (true)
        {
            spriteIndex = (spriteIndex + 1) % sprites.Length;
            spriteRenderer.sprite = sprites[spriteIndex];
            yield return new WaitForSeconds(spriteAnimationRate);
        }
    }

    public void ResetPlayer()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }
        
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameManager.Instance.GameOver();
        }
        else if (other.CompareTag("Scoring"))
        {
            GameManager.Instance.IncreaseScore();
        }
    }
}