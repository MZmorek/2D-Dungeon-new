using UnityEngine;

namespace Dungeons.Camera
{


    public class CameraMovement : MonoBehaviour
    {
        private Vector3 offset = new Vector3(0f, 0f, -10f);
        private float smoothTime = 0.001f;
        private Vector3 velocity = Vector3.zero;

        [SerializeField] private Transform target;

        void Update()
        {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}