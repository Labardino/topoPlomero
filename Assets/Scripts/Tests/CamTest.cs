using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamTest : MonoBehaviour
{
    public GameObject camObj;
    public CinemachineCameraOffset offsetty;
    public CinemachineVirtualCamera cammy;
    public CinemachineTrackedDolly dolyca;
    public CinemachineSmoothPath pathy;
    // Start is called before the first frame update
    void Start()
    {
        dolyca = cammy.GetCinemachineComponent<CinemachineTrackedDolly>();
        //dolyca.m_AutoDolly.m_PositionOffset = 1.0f;
    }
}
