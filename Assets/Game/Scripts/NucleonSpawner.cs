using UnityEngine;

public class NucleonSpawner : MonoBehaviour
{

	#region Public Members

	public float MaxNucleons;

	public float SpawnDistance;

	public float TimeBetweenSpawns;

	public Nucleon[] NucleonPrefabs;

	#endregion

	#region Private Members

	private float timeSinceLastSpawn;

	private int currentSpawns = 0;

	#endregion

	#region Public Methods

	public void FixedUpdate()
	{
		if (currentSpawns > MaxNucleons)
			return;

		timeSinceLastSpawn += Time.deltaTime;

		if (timeSinceLastSpawn >= TimeBetweenSpawns)
		{
			timeSinceLastSpawn -= TimeBetweenSpawns;

			SpawnNucleon();
		}
	}

	#endregion

	#region Private Methods

	public void SpawnNucleon()
	{
		var prefab = NucleonPrefabs[Random.Range(0, NucleonPrefabs.Length)];
		var spawn = Instantiate<Nucleon>(prefab);

		spawn.transform.localPosition = Random.onUnitSphere * SpawnDistance;

		currentSpawns++;
	}

	#endregion  
}