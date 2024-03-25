using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBehavior : MonoBehaviour
{
    [SerializeField] private Transform raycastOrigin;
    [SerializeField] float shootDistance = 10f;

    private DartBoothService _dartBoothService;

    // Start is called before the first frame update
    void Start()
    {
        _dartBoothService = FindObjectOfType<DartBoothService>();
    }

    public void Shoot(){
        RaycastHit hit;
        if(Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, shootDistance))
        {
            if (hit.transform.CompareTag("Balloon")){
                hit.transform.gameObject.SetActive(false);
                _dartBoothService.PopBalloon();
            }
        }
    }

}
