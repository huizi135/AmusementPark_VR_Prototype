using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingTossRingBehavior : MonoBehaviour
{
    private bool _isAroundBottle;
    private RingTossBoothService _ringTossBoothService;

    void Start()
    {
        _ringTossBoothService = FindObjectOfType<RingTossBoothService>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bottle"))
        {
           _isAroundBottle = true;
           StopAllCoroutines();
           StartCoroutine(ScoreDelay());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bottle"))
        {
          _isAroundBottle = false;
        }
    }

    private IEnumerator ScoreDelay()
    {
        yield return new WaitForSeconds(3f);
        if(_ringTossBoothService != null && _isAroundBottle)
        {
            _ringTossBoothService.AddToScore();
        }
    }

}
