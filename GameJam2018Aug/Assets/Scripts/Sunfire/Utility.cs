using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunfireUtility{
    public static class Utility
    {

        public static Vector3 GetRandomPointInBoxCollider(BoxCollider box)
        {
            Vector3 bLocalScale = box.transform.localScale;
            Vector3 boxPosition = box.transform.position;
            boxPosition += new Vector3(bLocalScale.x * box.center.x, bLocalScale.y * box.center.y, bLocalScale.z * box.center.z);

            Vector3 dimensions = new Vector3(bLocalScale.x * box.size.x,
            bLocalScale.y * box.size.y,
            bLocalScale.z * box.size.z);

            Vector3 newPos = new Vector3(UnityEngine.Random.Range(boxPosition.x - (dimensions.x / 2), boxPosition.x + (dimensions.x / 2)),
            UnityEngine.Random.Range(boxPosition.y - (dimensions.y / 2), boxPosition.y + (dimensions.y / 2)),
            UnityEngine.Random.Range(boxPosition.z - (dimensions.z / 2), boxPosition.z + (dimensions.z / 2)));
            return newPos;
        }

        public static Vector3 GetRandomPointInBoxCollider2D(BoxCollider2D box)
        {
            return new Vector3(Random.Range(box.bounds.min.x, box.bounds.max.x), Random.Range(box.bounds.min.y, box.bounds.max.y));
        }

        public static Transform FindDeepChild(this Transform aParent, string aName)
        {
            var result = aParent.Find(aName);
            if (result != null)
                return result;
            foreach (Transform child in aParent)
            {
                result = child.FindDeepChild(aName);
                if (result != null)
                    return result;
            }
            return null;
        }
    }

}
