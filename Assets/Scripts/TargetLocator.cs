using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{

    [SerializeField] Transform weapon;
    [SerializeField] Transform target;

    // Update is called once per frame

    private void Start() {
        target = FindObjectOfType<EnemyMover>().transform;    
    }

    void Update()
    {
        AimWeapon();
    }

    private void AimWeapon()
    {
        weapon.LookAt(target);
    }
}
