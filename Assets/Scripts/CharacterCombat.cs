using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    public float attackRange = 2f;
    public float attackCooldown = 1f;
    public int attackDamage = 10;
    public float knockbackForce = 5f;
    private float lastAttackTime = 0f;

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if(distanceToEnemy <= attackRange)
            {
                if(Time.time >= lastAttackTime + attackCooldown)
                {
                    Vector2 knockbackDirection = (enemy.transform.position - transform.position).normalized;
                    Attack(enemy, knockbackDirection);
                    lastAttackTime = Time.time;
                }
            }
        }
    }

    void Attack(GameObject enemy, Vector2 knockbackDirection)
    {
        enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage, knockbackDirection);
    }
}
