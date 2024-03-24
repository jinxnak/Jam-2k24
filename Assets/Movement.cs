using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
   public Transform[] waypoints; // Tableau des points de destination
    public float[] stopDurations; // Tableau des durées d'arrêt à chaque point
    public float speed = 5f; // Vitesse de déplacement
    private Animator animator;

    private int currentWaypointIndex = 0; // Index du point de destination actuel
    private float stopTimer = 0f; // Chronomètre pour mesurer la durée d'arrêt

    void Update()
    {
        // Vérifier si tous les points de destination ont été atteints
        if (currentWaypointIndex >= waypoints.Length)
        {
            // Réinitialiser l'index du point de destination pour recommencer le mouvement
            currentWaypointIndex = 0;
            return;
        }

        // Calculer la direction vers le point de destination actuel
        Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;

        // Si le GameObject est proche du point de destination actuel
        if (direction.magnitude < 0.1f)
        {
            // Démarrer le chronomètre d'arrêt
            stopTimer += Time.deltaTime;
             animator.SetBool("sate", true);

            // Si la durée d'arrêt est écoulée
            if (stopTimer >= stopDurations[currentWaypointIndex])
            {
                // Passer au prochain point de destination
                currentWaypointIndex++;
                stopTimer = 0f; // Réinitialiser le chronomètre d'arrêt
            }

            return;
        }

        // Normaliser la direction pour avoir une magnitude de 1
        // direction.Normalize();
        //  animator.SetBool("sate", false);
        // // Déplacer le GameObject dans la direction du point de destination actuel
        // transform.position += direction * speed * Time.deltaTime;

        // Calculer la nouvelle direction sans tenir compte de l'axe Y
        Vector3 lookAtDirection = direction;
        lookAtDirection.y = 0;

        // Si la direction n'est pas nulle, effectuer la rotation
        if (lookAtDirection != Vector3.zero)
        {
            // Créer une rotation basée sur la direction sans l'axe Y
            Quaternion targetRotation = Quaternion.LookRotation(lookAtDirection);

            // Appliquer la rotation au GameObject
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }
}
