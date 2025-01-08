using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFLibrary.NPC2D
{
    public class EnemyCondition2D : MonoBehaviour
    {
        public static bool TargetInCircle(Collider2D colliderBox, float size, LayerMask targetLayer)
        {
            Bounds bounds = colliderBox.bounds;
            Vector2 center = new Vector2(bounds.center.x, bounds.center.y);

            Collider2D hit = Physics2D.OverlapCircle(center, size, targetLayer);
            return hit;
        }

        public static Collider2D GetTargetInCircle(Collider2D colliderBox, float size, LayerMask targetLayer)
        {
            Bounds bounds = colliderBox.bounds;
            Vector2 center = new Vector2(bounds.center.x, bounds.center.y);

            Collider2D hit = Physics2D.OverlapCircle(center, size, targetLayer);
            return hit;
        }

        public static bool TargetInCircle(Collider2D colliderBox, float size, LayerMask targetLayer, out Collider2D detect)
        {
            Bounds bounds = colliderBox.bounds;
            Vector2 center = new Vector2(bounds.center.x, bounds.center.y);

            Collider2D hit = Physics2D.OverlapCircle(center, size, targetLayer);
            detect = hit;
            
            return hit;
        }
        
        public static bool IsFaceAtTarget(int faceDirection, int targetDirX)
        {
            return faceDirection == targetDirX;
        }
        
        public static bool TheSameLevelAsTarget(Vector3 targetPosition, Vector3 originPosition, LayerMask groundLayer)
        {
            RaycastHit2D targetGroundPosition = Physics2D.Raycast(targetPosition, Vector2.down, 1, groundLayer);
            RaycastHit2D originGroundPosition = Physics2D.Raycast(originPosition, Vector2.down, 1, groundLayer);

            Vector2 dir = targetGroundPosition.point - originGroundPosition.point;
        
            return dir.y <= 0.1f & dir.y >= -0.1f;
        }

        public static bool PathHaveObstacle(Collider2D colliderBox, Transform target, LayerMask obstacleLayer)
        {
            Vector2 dir = new Vector2(target.position.x - colliderBox.bounds.center.x,
                target.position.y - colliderBox.bounds.center.y).normalized;
            float distance = Vector2.Distance(colliderBox.bounds.center, target.position);

            RaycastHit2D hit = Physics2D.Raycast(colliderBox.bounds.center, dir, distance, obstacleLayer);
            return hit;
        }

        public static bool LittleSensor(Collider2D colliderBox, Vector2 dir, Vector2 offset, Vector2 size,
            LayerMask detectLayer)
        {
            Bounds bounds = colliderBox.bounds;
            Vector2 center = new Vector2(bounds.center.x, bounds.center.y) +
                             new Vector2(dir.x * bounds.size.x / 2, dir.y * bounds.size.y / 2) + size / 2;
            Collider2D hit = Physics2D.OverlapBox(center, size, 0, detectLayer);
            
            return hit;
        }
    }
}
