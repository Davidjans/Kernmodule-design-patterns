using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EventShowcase : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_Text;

    public void SetText(string _Text)
    {
        m_Text.text = _Text;
    }
}
