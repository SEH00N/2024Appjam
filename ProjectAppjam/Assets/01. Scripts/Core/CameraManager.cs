using System.Collections;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
	private static CameraManager instance;
    public static CameraManager Instance {
        get {
            if(instance==null)
                instance = FindObjectOfType<CameraManager>();
            return instance;
        }
    }

    private CinemachineVirtualCamera mainVCam;
    public CinemachineVirtualCamera MainVCam {
        get {
            if(mainVCam == null)
                mainVCam = GameObject.Find("MainVCam").GetComponent<CinemachineVirtualCamera>();
            return mainVCam;
        }
    }

    private Camera mainCam;
    public Camera MainCam {
        get {
            if (mainCam == null)
                mainCam = Camera.main;
            return mainCam;
        }
    }

    private CinemachineBasicMultiChannelPerlin perlin = null;
    private bool onShake = false;
    
    private void Awake()
    {
        perlin = MainVCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Start()
    {
        perlin.m_AmplitudeGain = 0f;
        perlin.m_FrequencyGain = 0f;
    }

    public void ShakeCam(float duration, float power, float frequency)
    {
        if(onShake) return;

        onShake = true;
        perlin.m_AmplitudeGain = power;
        perlin.m_FrequencyGain = frequency;
        Debug.Log($"{duration} {power} {frequency}");
        StartCoroutine(PerlinResetCoroutine(duration));
    }

    private IEnumerator PerlinResetCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        perlin.m_AmplitudeGain = 0f;
        perlin.m_FrequencyGain = 0f;

        onShake = false;
    }
}
