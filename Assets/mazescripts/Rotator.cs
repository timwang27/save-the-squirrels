using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.XR.ARFoundation.Samples
{
    public class Rotator : MonoBehaviour
    {
        float m_Angle;

        void Update()
        {
            m_Angle += Time.deltaTime * 20f;
            transform.rotation = Quaternion.Euler(0, m_Angle, 0);
        }
    }
}