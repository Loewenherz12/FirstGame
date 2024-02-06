using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossflip : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;

    public Transform attackPos;
    public LayerMask enemies;
    public float attackrange;
    


    public void Attack()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackrange, enemies);
        for (int i = 0; i <enemiesToDamage.Length;i++)
        {
            enemiesToDamage[i].GetComponent<Spieler> ().health += 1;
        }
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackrange);
    }

    public void LookAtPlayer()
    {
        if (player != null)
        {
            Vector3 flipped = transform.localScale;
            flipped.z *= -1f;

            if (transform.position.x > player.position.x && isFlipped)
            {
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                isFlipped = false;
            }
            else if (transform.position.x < player.position.x && !isFlipped)
            {
                transform.localScale = flipped;
                transform.Rotate(0f, 180f, 0f);
                isFlipped = true;
            }
        }
    }
}
