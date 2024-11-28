using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerConfig : MonoBehaviour
{
    private Vector3[] positions;

    private void Awake()
    {
        positions = new Vector3[2];
        positions[0] = transform.position;
        positions[1] = new Vector3(transform.position.x, transform.position.y - 6, 0);

        MoverSpawn mover = GetComponent<MoverSpawn>();
        if (mover != null)
        {
            mover.SetPositions(positions);
        }
    }

}
