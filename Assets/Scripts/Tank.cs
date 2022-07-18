using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private float _delayBetweenShoots;
    [SerializeField] private Transform _tankTowerPosition;
    [SerializeField] private float _tankTowerRecoilDestenation;

    private float _timeAfterShoot;
    private float _tankTowerAnimationDuration;

    private void Update()
    {
        _timeAfterShoot += Time.deltaTime;
        _tankTowerAnimationDuration = _timeAfterShoot;

        if (Input.GetMouseButton(0))
        {
            if (_timeAfterShoot > _delayBetweenShoots)
            {
                Shoot();
                TankAnimation();
                _timeAfterShoot = 0;
            }
        }
    }

    private void Shoot()
    {
        Instantiate(_bulletTemplate, _shootPoint.position, Quaternion.identity);
    }

    private void TankAnimation()
    {
        _tankTowerPosition.transform.DOLocalMoveZ(_tankTowerPosition.position.z, _tankTowerAnimationDuration);
        _tankTowerPosition.transform.DOLocalMoveZ(_tankTowerRecoilDestenation, _tankTowerAnimationDuration);
    }
}
