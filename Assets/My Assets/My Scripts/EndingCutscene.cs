using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class EndingCutscene : MonoBehaviour
{
    [SerializeField] GameObject _playerShip;
    [SerializeField] GameObject _carrierShip;
    [SerializeField] PlayableDirector _endingCutscene;
    [SerializeField] GameObject _implosion;
    [SerializeField] GameObject _portal;
    Vector3 _vfxPos;


    private void Start()
    {
        _vfxPos = new Vector3(-29.5001f, 72.37546f, 789.7159f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _playerShip.transform.parent = _carrierShip.transform;
            _endingCutscene.Play();
            StartCoroutine(StartPortalEffect());
        }
    }

    IEnumerator StartPortalEffect()
    {
        GameObject thisImplosion = Instantiate(_implosion, _vfxPos, Quaternion.identity);
        yield return new WaitForSeconds(.5f);
        GameObject thisPortal = Instantiate(_portal, _vfxPos, Quaternion.identity);
        yield return new WaitForSeconds(3f);
        Destroy(thisImplosion);
    }
}
