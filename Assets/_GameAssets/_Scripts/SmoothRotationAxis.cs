using System;
using UnityEngine;

namespace _GameAssets._Scripts
{
    public class SmoothRotationAxis : MonoBehaviour
    {
        public Transform target;
        public SmoothRotationAxisData[] datas;

        private void OnEnable()
        {
            EventManager.onDrag += RotateAxis;
        }

        private void OnDisable()
        {
            EventManager.onDrag -= RotateAxis;
        }

        private void RotateAxis(Vector2 startPosition, Vector2 previousPosition, Vector2 currentPosition)
        {
            var delta = currentPosition - previousPosition;
            foreach(var data in datas)
            {
                RotateAxis(data, delta,target);
            }
        }

        private void RotateAxis(SmoothRotationAxisData data, Vector3 delta, Transform targetRotate)
        {
            float angle = 0;
            switch(data.valueDirection)
            {
                case Axis.X:
                    angle = delta.x * data.speed;
                    break;
                case Axis.Y:
                    angle = delta.y * data.speed;
                    break;
                case Axis.Z:
                    angle = delta.z * data.speed;
                    break;
            }
            targetRotate.RotateAround(data.axis, angle);
        }
    }
    
    [Serializable]
    public class SmoothRotationAxisData
    {
        public float   speed = 1f;
        public Vector3 axis  = Vector3.right;
        public Axis valueDirection = Axis.X;
    }
}