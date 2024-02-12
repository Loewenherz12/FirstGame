using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossflip : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;

    public int Bosshealth;


    public Transform attackPos;
    public Transform smashPos;
    public LayerMask enemies;
    public float attackrange;
    public float smashrange;

    [SerializeField] private ParticleSystem SmashParticle = default;
    [SerializeField] private ParticleSystem AttackParticle = default;


    public void Attack()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackrange, enemies);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Spieler>().health += 1;
        }

    }
    public void Smash()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(smashPos.position, smashrange, enemies);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Spieler>().health += 1;
        }
    }
    public void ParticleSmashPlay()
    {
        SmashParticle.Play();

    }
    public void ParticleAttackPlay()
    {
        AttackParticle.Play();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackrange);

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(smashPos.position, smashrange);
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
    private void Update()
    {
        if (Bosshealth == 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Geisterball")
        {
            Bosshealth -= 1;
            
        }
    }
}
