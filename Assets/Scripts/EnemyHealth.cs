using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{

    [SerializeField] int maxHp = 5;

    [Tooltip("Adds amount to maxHitpoints when enemy dies")]
    [SerializeField] int difficultyRamp = 1;

    int currentHp = 0;

    Enemy enemy;

    private void Start() {
        enemy = GetComponent<Enemy>();
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        currentHp = maxHp;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (currentHp < 1)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        gameObject.SetActive(false);
        enemy.RewardGold();
        maxHp += difficultyRamp;
    }

    private void ProcessHit()
    {
        currentHp -= 1;
    }


}
