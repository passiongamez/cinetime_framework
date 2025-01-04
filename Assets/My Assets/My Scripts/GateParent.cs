using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class GateParent : MonoBehaviour
{
    [SerializeField] GameObject _bigShipDirector;
    [SerializeField] bool _bigShipArrived = false;
    [SerializeField] GameObject _implosion;
    [SerializeField] GameObject _portal;
    Vector3 _vfxPos;


    private void Start()
    {
        _vfxPos = new Vector3(-5.8f, 134.2f, 742);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && _bigShipArrived == false)
        {
            StartCoroutine(StartPortalEffect());
            _bigShipDirector.SetActive(true);
            _bigShipArrived = true;
            Debug.Log("Ship has called for extraction");
        }
    }

    IEnumerator StartPortalEffect()
    {
       GameObject thisImplosion = Instantiate(_implosion, _vfxPos, Quaternion.identity);
        yield return new WaitForSeconds(.5f);
       GameObject thisPortal = Instantiate(_portal, _vfxPos, Quaternion.identity);
        yield return new WaitForSeconds(3f);
        Destroy(thisImplosion);
        Destroy(thisPortal);
    }
}
