using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class BaseEvent
{
    public EventType m_EventType = EventType.Kill;  
    public float m_Delay;
    public bool m_IsSent;
    public object m_Data;

    public BaseEvent(EventType _eventType, float _delay, object _data)
    {
        m_EventType = _eventType;
        m_Delay = _delay;
        m_Data = _data;
        m_IsSent = false;
    }
    
    public void Reset()
    {
        m_Data = null;
        m_IsSent = false;
        m_Delay = 0.0f;
    }
}
