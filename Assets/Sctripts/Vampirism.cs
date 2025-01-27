using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Detector _detector;
    [SerializeField] private InputManager _inputManager;

    [SerializeField] private int _workTimeAbility = 6;
    [SerializeField] private int _reloadTimeAbility = 4;
    [SerializeField] private int _pauseTimeBetweenBars = 1;
    [SerializeField] private int _powerAbility = 5;

    //private WaitForSeconds _waitForSecondsWorkTimeAbility; //¬озможно удалить за ненадобностью.
    //private WaitForSeconds _waitForSecondsReloadTimeAbility;
    //private WaitForSeconds _waitForSecondsPauseTimeBetweenBars;

    private Coroutine _abilityProcess;
    private Coroutine _reload;

    private bool _isReady = true;

    //private void Start()
    //{
    //    _waitForSecondsWorkTimeAbility = new WaitForSeconds(_workTimeAbility); //¬озможно удалить за ненадобностью.
    //    _waitForSecondsReloadTimeAbility = new WaitForSeconds(_reloadTimeAbility);
    //    _waitForSecondsPauseTimeBetweenBars = new WaitForSeconds(_pauseTimeBetweenBars);
    //}

    private void OnEnable()
    {
        _inputManager.KeyHasPressed += TryApplyAbility;
    }

    private void OnDisable()
    {
        _inputManager.KeyHasPressed -= TryApplyAbility;
    }

    //private IEnumerator StartVampirise()
    //{
    //    for (float t = 0; t <= _workTimeAbility; t += Time.deltaTime) //¬рем€ –аботы способности 6 сек. даже если врем€ между тактами 0.02 сек работает способность не менее 6 сек!!!
    //                                                                  //проверить это!
    //    {
    //        ITakingDamage enemy = _detector.IdentifyNearestTarget();

    //        if (enemy != null)
    //        {
    //            enemy.TakeDamage(_powerAbility);
    //            _player.TryToAcceptLifeForce(_powerAbility);
    //        }

    //        yield return _waitForSecondsPauseTimeBetweenBars; //1 sek
    //    }

    //    yield return _waitForSecondsReloadTimeAbility;
    //}

    private IEnumerator StartVampirise()
    {
        _isReady = false;

        int barsCount = _workTimeAbility / _pauseTimeBetweenBars; //считаем сколько раз за 6 секунд

        for (int i = 0; i < barsCount; i++) 
        {
            ITakingDamage enemy = _detector.IdentifyNearestTarget();

            if (enemy != null)
            {
                enemy.TakeDamage(_powerAbility);
                _player.TryToAcceptLifeForce(_powerAbility);
            }

            yield return new WaitForSeconds(_pauseTimeBetweenBars);
        }

        StartCoroutine(Reload());
        StopVampirism();
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(_reloadTimeAbility);

        _isReady = true;

        yield break;
    }

    private void StopVampirism()
    {
        if (_abilityProcess == null) return;

        StopCoroutine(_abilityProcess);
        _abilityProcess = null;
    }

    private void TryApplyAbility()
    {
        Debug.Log("TryApplyAbility");

        if (_abilityProcess == null && _isReady)
        {
            //јктивировать внешний фон
            _abilityProcess = StartCoroutine(StartVampirise());
        }
    }
}
