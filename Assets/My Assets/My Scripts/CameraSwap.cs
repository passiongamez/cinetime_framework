using Unity.Cinemachine;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    [SerializeField] CinemachineCamera[] _cinecams;
    [SerializeField] int _currentCamera = 0;
    [SerializeField] GameObject _cockPit;
    [SerializeField] GameObject _ship;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _currentCamera++;
            if (_currentCamera > _cinecams.Length - 1)
            {
                _currentCamera = 0;
            }
            ResetCameraPriorities();
            SetPriority();
        }
    }


    void ResetCameraPriorities()
    {
        foreach(var camera in _cinecams)
        {
            camera.GetComponent<CinemachineCamera>().Priority = 0;
        }
    }

    void SetPriority()
    {
        _cinecams[_currentCamera].GetComponent<CinemachineCamera>().Priority = 1;
        if (_currentCamera == 0)
        {
            _cockPit.SetActive(false);
        }
        else
        {
            _cockPit.SetActive(true);
        }
    }
}
