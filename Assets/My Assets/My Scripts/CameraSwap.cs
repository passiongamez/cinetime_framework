using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraSwap : MonoBehaviour
{
    [SerializeField] CinemachineCamera[] _cinecams;
    [SerializeField] CinemachineSequencerCamera _cinematicCam;
    [SerializeField] int _currentCamera = 0;
    [SerializeField] GameObject _cockPit;
    [SerializeField] GameObject _ship;
    [SerializeField] float _idleTime;
    [SerializeField] float _waitTime = 10f;
    [SerializeField] bool _cinematicsOn = false;


    private void Update()
    {
        IdleGameSequence();
        if (Input.GetKeyDown(KeyCode.R))
        {
            _currentCamera++;
            if (_currentCamera > _cinecams.Length - 1)
            {
                _currentCamera = 0;
            }
            TurnOffCinematicCams();
            ResetCameraPriorities();
            SetPriority();
        }

        if(_idleTime >= _waitTime && _cinematicsOn == false)
        {
            CinematicCameraStart();
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

    void CinematicCameraStart()
    {
        _cinematicCam.gameObject.SetActive(true);
        _cinematicCam.GetComponent<CinemachineSequencerCamera>().Priority = 5;
        _cinematicsOn = true;
    }
    void TurnOffCinematicCams()
    {
        _cinematicCam.gameObject.SetActive(false);
        _cinematicsOn = false;
    }


    void IdleGameSequence()
    {
        _idleTime += Time.deltaTime;
        if (Input.anyKey || Input.mousePositionDelta.x > 0 || Input.mousePositionDelta.y > 0)
        {
            _idleTime = 0;
            TurnOffCinematicCams();
        }
    }
}
