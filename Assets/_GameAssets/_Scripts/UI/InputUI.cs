using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace ComponentUtilitys
{
    public class InputUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        private Vector2 _startPosition;
        private Vector2 _previousPosition;

        /// <summary>
        /// Được gọi khi phát hiện sự kiện nhấn chuột.
        /// </summary>
        /// <param name="eventData">Dữ liệu sự kiện chuột.</param>
        public void OnPointerDown(PointerEventData eventData)
        {
            _startPosition    = eventData.position;
            _previousPosition = eventData.position;
            EventManager.onPointerDown?.Invoke(eventData.position);
        }

        /// <summary>
        /// Được gọi khi phát hiện sự kiện thả chuột.
        /// </summary>
        /// <param name="eventData">Dữ liệu sự kiện chuột.</param>
        public void OnPointerUp(PointerEventData eventData)
        {
            EventManager.onPointerUp?.Invoke(eventData.position);
        }
        /// <summary>
        /// Được gọi khi phát hiện sự kiện kéo chuột.
        /// </summary>
        /// <param name="eventData">Dữ liệu sự kiện chuột.</param>
        public void OnDrag(PointerEventData eventData)
        {
            var currentPosition = eventData.position;
            EventManager.onDrag?.Invoke(_startPosition, _previousPosition, currentPosition);
            _previousPosition = currentPosition;
        }
        
    }
}