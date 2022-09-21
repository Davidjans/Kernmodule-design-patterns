using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

public enum EventType
{
    Kill,
    Notification,
    Disconnect,
    Objective
}


public class EventQueue : SerializedMonoBehaviour
{
    [SerializeField] private Dictionary<EventType, GameObject> m_EventBackground;
    [SerializeField] private List<BaseEvent> m_Events = new List<BaseEvent>();

    public void Start()
    {
        Add(new BaseEvent(EventType.Kill,5,"cummies"));
        Add(new BaseEvent(EventType.Notification,5,"dsafadsf"));
        Add(new BaseEvent(EventType.Disconnect,5,"2351234"));
        Add(new BaseEvent(EventType.Objective,5,"22222"));
    }
    
    
    public void Add(BaseEvent e)
    {
        m_Events.Add(e);
        if (m_Events.Count == 1)
        {
            PublishEvent();
        }
    }

    virtual async public void PublishEvent()
    {
        if (m_Events.Count <= 0)
            return;
        GameObject selectedBackground = m_EventBackground[m_Events[0].m_EventType];
        selectedBackground.SetActive(true);
        selectedBackground.GetComponent<EventShowcase>().SetText(m_Events[0].m_Data.ToString());
        await Task.Delay((int)(m_Events[0].m_Delay * 1000));
        selectedBackground.SetActive(false);
        m_Events[0].m_IsSent = true;
        m_Events.RemoveAt(0);
        PublishEvent();
    }
    
    public void ClearEvents()
    {
        m_Events.Clear();
    }
}
