
using UnityEngine;

public class StrongmanStrikePadBehavior : MonoBehaviour
{
		private StrongmanService _strongmanService;

	private void Start()
	{
		_strongmanService = FindObjectOfType<StrongmanService>();
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.CompareTag("Hammer"))
		{
			var hammerRigidbody = collision.gameObject.GetComponentInParent<Rigidbody>();
			var hammerBehavior = collision.gameObject.GetComponentInParent<StrongmanHammerBehavior>();

			_strongmanService.Strike(
				hammerRigidbody.mass, 
				collision.relativeVelocity.magnitude, 
				hammerBehavior.StrikeMultiplier);
		}
	}
}
