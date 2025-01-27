using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Gold _prefab;
    private int _maximumCreateSeconds = 10;

    private void Start()
    {
        StartCoroutine(SpawnGold());
    }

    private IEnumerator SpawnGold()
    {
        yield return new WaitForSeconds(Random.Range(0, _maximumCreateSeconds));
        Instantiate<Gold>(_prefab, transform.position, Quaternion.identity);
    }
}
