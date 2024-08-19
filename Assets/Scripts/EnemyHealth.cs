using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public float knockbackForce = 5f;
    public float knockbackDuration = 0.2f;
    private int currentHealth;
    private bool isKnockedBack = false;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Rigidbody2D rb;


    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage, Vector2 knockbackDirection)
    {
        currentHealth -= damage;
        StartCoroutine(ChangeColor());
        StartCoroutine(Knockback(knockbackDirection));
        
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    private IEnumerator Knockback(Vector2 knockbackDirection)
    {
        isKnockedBack = true;
        rb.velocity = Vector2.zero;
        rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(knockbackDuration);

        rb.velocity = Vector2.zero;
        isKnockedBack = false;
    }

    private IEnumerator ChangeColor()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = originalColor;
    }
}
