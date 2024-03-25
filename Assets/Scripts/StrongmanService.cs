using UnityEngine;
using System;
using System.Collections;


public class StrongmanService : MonoBehaviour
{
	[SerializeField] private Transform slider;
	[SerializeField] private float maxHeight= 6.63f;
	[SerializeField] private float sliderDuration = 1f;

	private float _initialSliderHeight;
	private bool _isSliderMoving;

	private void Start()
	{
		_initialSliderHeight = slider.localPosition.y;
	}

	public void Strike(float mass, float velocity, float strikeMultiplier)
	{
		Debug.Log("Strike! With a mass of " + mass 
		        + " and a velocity of " + velocity 
				+ " and a multiplier of " + strikeMultiplier);

		//physic calculation
		float impactForce = mass * velocity;

		//move the slider
		float sliderHeight = Mathf.Clamp(
		impactForce * strikeMultiplier, 
		_initialSliderHeight,
		maxHeight);

		if(!_isSliderMoving)
		{
		StartCoroutine(MoveSlider(sliderHeight));
		}
		
	}

	private IEnumerator MoveSlider(float targetHeight)
	{
		_isSliderMoving = true;
		//set up
		Vector3 startPos = new Vector3(
			slider.localPosition.x,
			_initialSliderHeight,
			slider.localPosition.z
		);
		Vector3 endPos = new Vector3(
			slider.localPosition.x,
			targetHeight,
			slider.localPosition.z
		);

		// slider moving up
		float elapsedTime = 0f;
		while (elapsedTime < sliderDuration)
		{
			slider.localPosition = Vector3.Lerp(startPos, endPos, elapsedTime / sliderDuration);
			elapsedTime += Time.deltaTime;
			yield return null;
		}

		// slider paused
		yield return new WaitForSeconds(sliderDuration);
	
		// slider moving down
		elapsedTime = 0f;
		while (elapsedTime < sliderDuration)
		{
			slider.localPosition = Vector3.Lerp(endPos, startPos, elapsedTime / sliderDuration);
			elapsedTime += Time.deltaTime;
			yield return null;
		}

		_isSliderMoving = false;
	}

}
