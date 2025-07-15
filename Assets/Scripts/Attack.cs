using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	[SerializeField] private KeyCode attackKey = KeyCode.Space;
	[SerializeField] private float attackRange = 0.5f;
	[SerializeField] private Transform attackPoint;
	[SerializeField] private LayerMask enemyLayers;

	void Update()
	{
		if (Input.GetKeyDown(attackKey))
		{
			Debug.Log("Attack button pressed!");
			PerformAttack();
		}
	}

	void PerformAttack()
	{
		// Visual debug
		Debug.Log("Player performed an attack.");

		// Detect enemies in range
		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

		// Damage them (placeholder)
		foreach (Collider2D enemy in hitEnemies)
		{
			Debug.Log("Hit enemy: " + enemy.name);
			// You can call enemy.TakeDamage() here if that script exists
		}
	}

	// Draw the attack range in the editor
	void OnDrawGizmosSelected()
	{
		if (attackPoint == null)
			return;

		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(attackPoint.position, attackRange);
	}
}
