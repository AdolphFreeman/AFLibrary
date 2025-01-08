using UnityEngine;

namespace AFLibrary
{
    public class CalculationTool
    {
        public static float Remap(float min1, float max1, float max2)
        {
            return min1 * max2 / max1;
        }

        public static float CalculateAngleBetween2Vector(Vector3 a, Vector3 b)
        {
            Vector3 direction = a - b;
            return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }
    }
}
