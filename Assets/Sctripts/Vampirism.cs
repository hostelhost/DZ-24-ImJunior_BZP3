using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _detectorZoneDisplay;
    [SerializeField] private Player _player;
    [SerializeField] private DetectorVampire _detector;
    [SerializeField] private InputReader _inputReader;

    [SerializeField] private int _workTimeAbility = 6;
    [SerializeField] private int _reloadTimeAbility = 4;
    [SerializeField] private int _pauseTimeBetweenBars = 1;
    [SerializeField] private int _powerAbility = 5;

    private WaitForSeconds _waitForSecondsReloadTimeAbility;
    private WaitForSeconds _waitForSecondsPauseTimeBetweenBars;

    private bool _isBusy = false;

    private void Start()
    {
        _waitForSecondsReloadTimeAbility = new WaitForSeconds(_reloadTimeAbility);
        _waitForSecondsPauseTimeBetweenBars = new WaitForSeconds(_pauseTimeBetweenBars);
        _detectorZoneDisplay.enabled = false;
    }

    private void OnEnable()
    {
        _inputReader.KeyHasPressed += TryApplyAbility;
    }

    private void OnDisable()
    {
        _inputReader.KeyHasPressed -= TryApplyAbility;
    }

    private IEnumerator StartVampirise()
    {
        int barsCount = _workTimeAbility / _pauseTimeBetweenBars;

        for (int i = 0; i < barsCount; i++)
        {
            if (_detector.TryIdentifyNearestTarget(out Enemy enemy))
            {
                enemy.TakeDamage(_powerAbility);
                _player.TryToAcceptLifeForce(_powerAbility);
            }

            yield return _waitForSecondsPauseTimeBetweenBars;
        }

        _detectorZoneDisplay.enabled = false;

        yield return _waitForSecondsReloadTimeAbility;

        _isBusy = false;
    }

    private void TryApplyAbility()
    {
        if (_isBusy == false)
        {
            _detectorZoneDisplay.enabled = true;
            StartCoroutine(StartVampirise());
            _isBusy = true;
        }
    }
}
