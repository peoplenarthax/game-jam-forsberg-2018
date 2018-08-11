using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour {

    public static Vector3 FindNextTargetInRadius(Vector3 pos, float radius, int negativeLayerMask, int positiveLayerMask){
        Vector2 targetV2pos = Random.insideUnitCircle * radius;
        Vector3 targetPos = new Vector3(targetV2pos.x, targetV2pos.y) + pos;
        //GameObject go = new GameObject();
        //CircleCollider2D col = go.AddComponent<CircleCollider2D>();
        //ColliderChecker colliderChecker = go.AddComponent<ColliderChecker>();
        //colliderChecker.layerMaskToCheck = layerMask;
        //col.radius = 0.5f;
        ////go.transform.position = targetPos;
        //if (colliderChecker.IsColliding == true){
        //    Debug.Log("colliding");
        //    targetPos = FindNextTargetInRadius(pos, radius, layerMask);
        //}
        //Debug.Log(LayerMask.LayerToName(layerMask));
        Collider2D[] collider2Ds = new Collider2D[5];
        int isColliding = Physics2D.OverlapCircleNonAlloc(targetPos, 0.5f, results: collider2Ds, layerMask: 1 << negativeLayerMask);
        int isWithinTargetArea;
        if (positiveLayerMask == -1){
            isWithinTargetArea = 1;
        } else {
            isWithinTargetArea = Physics2D.OverlapCircleNonAlloc(targetPos, 0.5f, results: collider2Ds, layerMask: 1 << positiveLayerMask);
        }
        if (isColliding > 0 && isWithinTargetArea <= 0){
            //Debug.Log("hi");
            targetPos = FindNextTargetInRadius(pos, radius, negativeLayerMask, positiveLayerMask);
        }
        return (targetPos);
    }
}
