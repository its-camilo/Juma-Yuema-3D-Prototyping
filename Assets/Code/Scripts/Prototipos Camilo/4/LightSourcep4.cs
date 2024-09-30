using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSourcep4 : MonoBehaviour
{
    public EnemyVisionp4 enemyVision;  // Referencia al script del enemigo

    // Cuando el proyectil impacte la luz
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            // Notificamos al enemigo que la luz ha sido destruida
            enemyVision.DisableVision();
            
            // Destruimos la luz
            Destroy(this.gameObject);
        }
    }
}