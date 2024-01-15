using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosCheck : MonoBehaviour
{
    public LayerMask objects;

    private EnemyMoveController enemyMoveController;

    private void Awake()
    {
        enemyMoveController = GetComponentInParent<EnemyMoveController>();
    }

    void Update()
    {
        bool isObject = Physics2D.OverlapCircle(transform.position, 0.15f, objects);
        if (isObject) enemyMoveController.Jump();

    }
}
