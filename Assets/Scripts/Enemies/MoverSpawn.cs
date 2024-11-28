using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverSpawn : MonoBehaviour
{
    public float speed = 1f; // Velocidad de movimiento
    private Vector3[] positions; // Posiciones a las que se moverá
    private int currentTargetIndex = 0;

    public void SetPositions(Vector3[] positions)
    {
        this.positions = positions;
    }

    private void Start()
    {
        StartCoroutine(MoveBetweenPositions());
    }

    private IEnumerator MoveBetweenPositions()
    {
        while (positions != null && positions.Length > 0)
        {
            Vector3 targetPosition = positions[currentTargetIndex];
            while (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                yield return null;
            }
            currentTargetIndex = (currentTargetIndex + 1) % positions.Length;
        }
    }

}
