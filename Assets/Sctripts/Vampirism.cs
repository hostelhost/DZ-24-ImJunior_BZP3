using System;
using System.Collections;
using System.Threading;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private DetectorZoneDisplay _detectorZone;
    [SerializeField] private Player _player;
    [SerializeField] private Detector _detector;
    [SerializeField] private InputManager _inputManager;

    [SerializeField] private int _workTimeAbility = 6;
    [SerializeField] private int _reloadTimeAbility = 4;
    [SerializeField] private int _pauseTimeBetweenBars = 1;
    [SerializeField] private int _powerAbility = 5;

    private WaitForSeconds _waitForSecondsReloadTimeAbility;
    private WaitForSeconds _waitForSecondsPauseTimeBetweenBars;

    private ITakingDamage _enemy;
    private bool _isBusy = false;

    public event Action StartedWork;

    public bool IsWorking { get; private set; } = false;

    private void Start()
    {
        _waitForSecondsReloadTimeAbility = new WaitForSeconds(_reloadTimeAbility);
        _waitForSecondsPauseTimeBetweenBars = new WaitForSeconds(_pauseTimeBetweenBars);
        _detectorZone.enabled = false; //���������� ������ �� ����������� ������� ���
    }

    private void OnEnable()
    {
        _inputManager.KeyHasPressed += TryApplyAbility;
    }

    private void OnDisable()
    {
        _inputManager.KeyHasPressed -= TryApplyAbility;
    }

    private IEnumerator StartVampirise()
    {
        int barsCount = _workTimeAbility / _pauseTimeBetweenBars;

        for (int i = 0; i < barsCount; i++)
        {
            _enemy = _detector.IdentifyNearestTarget();

            if (_enemy != null)
            {
                _enemy.TakeDamage(_powerAbility);
                _player.TryToAcceptLifeForce(_powerAbility);
            }

            yield return _waitForSecondsPauseTimeBetweenBars;
            IsWorking = false;
        }

        _detectorZone.enabled = false; //���������� ������ �� ����������� ������� ���

        yield return _waitForSecondsReloadTimeAbility;

        _isBusy = false;
    }

    private void TryApplyAbility()
    {
        if (_isBusy)
        {
            _detectorZone.enabled = true; //���������� ������ �� ����������� ������� ���
            StartCoroutine(StartVampirise());
            StartedWork?.Invoke();
            IsWorking = true;
            _isBusy = true;
        }
    }
}
