using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Utilities;

namespace InfluencerWorld.Input
{
    [RequireComponent(typeof(BoxCollider2D))]
    public sealed class Interactable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler, IBeginDragHandler
    {

        public BoxCollider2D DraggableArea;
        public bool          Draggable;
        public bool          ConstrainX;
        public bool          ConstrainY;
        public UnityEvent    OnTapped;
    
        public void OnPointerDown(PointerEventData eventData)
        {
            OnTapped?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
        
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!Draggable) return;
        
            var pos               = Camera.main.ScreenToWorldPoint(eventData.position);
            if (ConstrainX) pos.x = transform.position.x;
            if (ConstrainY) pos.y = transform.position.y;
            if (DraggableArea.bounds.ToRect().Contains(pos))
            {
                transform.WorldXY(pos.x,pos.y);
            }
        
        }

        public void OnEndDrag(PointerEventData eventData)
        {
        
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
        
        }
    }
}
