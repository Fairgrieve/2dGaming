using System.Collections;
using Unity.Collections;
using UnityEngine;

// hahah lmao im doing some work

// Inspector screams at you if you forget it
[RequireComponent(typeof(Rigidbody2D))]
public class AI : MonoBehaviour
{
    [Header("Hunting")]
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 5.0f;
    
    [Header("Damage")]
    [SerializeField] private int damage = 10;
    
    [Header("Knockback")]
    [SerializeField] private float knockbackForce = 5.0f;
    [SerializeField] private float knockbackTime = 0.25f;
    
    [Header("Debug")]
    [SerializeField] private bool canMove = true;
    [SerializeField] private bool canDamage = true;
    
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        
        // If cant move or no player do nothing
        if (!canMove || target == null) return;
        
        // Lock on and move towards the player
        Vector2 dir = (target.position - transform.position).normalized;
        rb.linearVelocity = dir * speed;
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        // Only react if we hit the player (object on player tag)
        if (!col.collider.CompareTag("Player")) return;

        // Get hit away from player
        Vector2 away = (transform.position - col.transform.position).normalized;
        
        if (canDamage)
        {
            PlayerHealth hp = col.collider.GetComponent<PlayerHealth>();
            if (hp != null) hp.TakeDamage(damage);
        }

        // Clear hunting and knockback
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(away * knockbackForce, ForceMode2D.Impulse);

        // stunlock this mfer
        StartCoroutine(KnockbackStall());
    }

    IEnumerator KnockbackStall()
    {
        canMove = false;
        yield return new WaitForSeconds(knockbackTime);
        canMove = true;
    }
}
