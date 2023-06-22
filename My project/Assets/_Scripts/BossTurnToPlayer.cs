using UnityEngine;

public class BossTurnToPlayer : MonoBehaviour
{
    public Transform bossTransform;
    public Transform playerTransform;
    public float rotationSpeed = 1f;
    public float turnDistance = 10f;
    public float moveSpeed = 1f;
    public float maxMoveDistance = 20f;
    public float maxRadius = 5f; //maximum radius from initial position

    private Vector3 initialPosition;



    private void Start()
    {
        initialPosition = transform.position;
    }
    void Update()
    {
        float distance = Vector3.Distance(bossTransform.position, playerTransform.position);

        if (distance < turnDistance)
        {
            Vector3 direction = Vector3.Normalize(playerTransform.position - bossTransform.position);
            direction.y = 0f; // Constrain the boss on the x-z plane
            float dot = Vector3.Dot(direction, bossTransform.forward);

            if (dot > 0)
            {
                bossTransform.rotation = Quaternion.RotateTowards(bossTransform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            }
            else
            {
                bossTransform.rotation = Quaternion.RotateTowards(bossTransform.rotation, Quaternion.LookRotation(-direction), rotationSpeed * Time.deltaTime);
            }

            // Move the boss towards the player within a limited range
            Vector3 moveDirection = direction;
            Vector3 randomOffset = Random.insideUnitCircle.normalized * maxRadius;
            Vector3 targetPosition = initialPosition + randomOffset;
            targetPosition.y = transform.position.y; // Constrain the boss on the y-axis
            float distanceToTarget = Vector3.Distance(transform.position, targetPosition);
            if (distanceToTarget > maxMoveDistance)
            {
                targetPosition = transform.position + (targetPosition - transform.position).normalized * maxMoveDistance;
            }
            Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            transform.position = newPosition;
        }
    }
}
