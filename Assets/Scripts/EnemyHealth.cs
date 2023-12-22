using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] int maxHp = 5;
    int currentHp = 0;
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
    }

    private void ProcessHit()
    {
        currentHp -= 1;
    }


}
