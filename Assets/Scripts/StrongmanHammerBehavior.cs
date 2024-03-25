
using UnityEngine;

public class StrongmanHammerBehavior : MonoBehaviour
{
	public float StrikeMultiplier => strikeMultiplier;
	[SerializeField] private float strikeMultiplier = 0.01f;

	[SerializeField] private Transform centerOfMass;

	private Rigidbody _rigidbody;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	private void Start()
	{
		_rigidbody.centerOfMass = centerOfMass.localPosition;
	}
}
