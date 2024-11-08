using System;
using UnityEngine;
using UnityEngine.Events;
using VInspector;

namespace UnityHelper
{
    public class ButtonEvent : ButtonBase
    {
            [Tab("Button Event")]
            //One Way
            [SerializeField]
            private EventDataInfo _eventOnInfo;
            //Two Way
            [SerializeField,ShowIf("_buttonTypeWay","Two Way")]
            private EventDataInfo _eventOffInfo;
            [EndIf]
            //
            [EndTab]
            private void HandleEventDispatcher(bool state = false)
            {
                var eventAction = _eventOnInfo.dispatcherEventInfo;
                if (_buttonTypeWay.Equals("Two Way") && !state)
                {
                    eventAction = _eventOffInfo.dispatcherEventInfo;
                }

                eventAction.PostEvent();
                
            }
        
            private void HandleEventUnity(bool state = false)
            {
                var eventAction = _eventOnInfo.unityEvent;

                if (_buttonTypeWay.Equals("Two Way") && !state)
                {
                    eventAction = _eventOffInfo.unityEvent;
                }
                eventAction?.Invoke();
            }

            public override void OnClick()
            {
                HandleEventUnity();
                HandleEventDispatcher();
            }

            public override void OnChangeValue<T>(T value)
            {
                if (value is not bool boolValue) return;
                HandleEventUnity(boolValue);
                HandleEventDispatcher(boolValue);
            }
    }

    [Serializable]
    public struct EventDataInfo
    {
        public DispatcherEventInfo dispatcherEventInfo;
        public UnityEvent unityEvent;
    }


    [Serializable]
    public struct DispatcherEventInfo
    {
        public EventID        eventID;
        public EventPostValue eventValue;
        
        public bool PostEvent()
        {
            if (eventID == EventID.None) return false;
            EventDispatcher.Instance.PostEvent(eventID,eventValue.GetValuePost());
            return true;
        }
    }

    [Serializable]
    public struct EventPostValue
    {
        public PrimitiveDataType valuePostType;
        public int @int;
        public float @float;
        public string @string;
        public bool @bool;

        public object GetValuePost()
        {
            object value = valuePostType switch
            {
                    PrimitiveDataType.Int => @int,
                    PrimitiveDataType.Float => @float,
                    PrimitiveDataType.String => @string,
                    PrimitiveDataType.Bool => @bool,
                    _                     => null
            };

            return value;
        }
    }
}