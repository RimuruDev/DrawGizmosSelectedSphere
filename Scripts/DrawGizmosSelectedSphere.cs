using UnityEngine;

namespace RimuruDev.Helpers
{
    public sealed class DrawGizmosSelectedSphere : MonoBehaviour
    {
        [SerializeField, Range(0.1f, 100)] private float radius;
        [SerializeField] private DrawGizmosColor drawGizmosColor;
        [Space]
        [SerializeField] private bool isDrawGizmos;

        private readonly float minRadius = 0.1f;
        private readonly float maxRadius = 100f;
        private readonly float defaultRadius = 1f;

        private void Reset()
        {
            drawGizmosColor = DrawGizmosColor.Red;
            radius = defaultRadius;
            isDrawGizmos = true;
        }

        private void OnValidate()
        {
            if (radius < minRadius || radius > maxRadius)
                radius = 1f;
        }

        private void OnDrawGizmos()
        {
            if (!isDrawGizmos) return;

            Gizmos.color = drawGizmosColor switch
            {
                DrawGizmosColor.Red => Color.red,
                DrawGizmosColor.Blue => Color.blue,
                DrawGizmosColor.Yello => Color.yellow,
                DrawGizmosColor.Green => Color.green,
                DrawGizmosColor.Cyan => Color.cyan,
                _ => Color.red,
            };
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }

    public enum DrawGizmosColor { Red, Green, Blue, Yello, Cyan }
}