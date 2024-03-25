using UnityEngine;

public class PrizeManager : MonoBehaviour
{
	public static PrizeManager Instance;

	[SerializeField] private int ringTossPrizeScore = 20;
	[SerializeField] private GameObject ringTossTicketPrefab;
	[SerializeField] private Transform ringTossTicketSpawnPoint;
	[SerializeField] private bool hasSpawnedRingTossTicket;

	private RingTossBoothService _ringTossBoothService;

	private void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(this);
		}
	}

	private void Start()
	{
		_ringTossBoothService = FindObjectOfType<RingTossBoothService>();
		_ringTossBoothService.ScoreUpdated += HandleRingTossScoreChange;
	}

	private void OnDestroy()
	{
		_ringTossBoothService.ScoreUpdated -= HandleRingTossScoreChange;
	}

	private void HandleRingTossScoreChange(int newScore)
	{
		if(!hasSpawnedRingTossTicket && newScore >= ringTossPrizeScore)
		{
			Instantiate(
				ringTossTicketPrefab,
				ringTossTicketSpawnPoint.position,
				ringTossTicketSpawnPoint.rotation);

			hasSpawnedRingTossTicket = true;
		}
	}

}
