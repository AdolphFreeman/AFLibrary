using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFLibrary
{
    public class BasicCondition : MonoBehaviour
    {
        public static bool OnGround2D(Collider2D colliderBox, float height, LayerMask groundLayer)
        {
            Bounds bounds = colliderBox.bounds;
            Vector2 center = new Vector2(bounds.center.x, bounds.center.y - (bounds.size.y + height) / 2);
            Vector2 size = new Vector2(bounds.size.x, height);

            Collider2D hit = Physics2D.OverlapBox(center, size, 0, groundLayer);

            return hit;
        }

        public static bool InGround2D(Collider2D colliderBox, float scaleX, float scaleY, LayerMask groundLayer)
        {
            Bounds bounds = colliderBox.bounds;
            Vector2 center = new Vector2(bounds.center.x, bounds.center.y);
            Vector2 size = new Vector2(bounds.size.x * scaleX, bounds.size.y * scaleY);
            
            Collider2D hit = Physics2D.OverlapBox(center, size, 0, groundLayer);

            return hit;
        }
    }
}
