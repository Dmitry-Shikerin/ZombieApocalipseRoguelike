using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.PresentationsInterfaces.Views.Character;
using Sources.PresentationsInterfaces.Views.Coins;
using Sources.PresentationsInterfaces.Views.ObjectPools;
using UnityEngine;

namespace Sources.Presentations.Views.Coins
{
    public class CoinView : View, ICoinView
    {
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private AnimationCurve _animationCurve;

        private ICharacterWalletView _characterWalletView;
        private CancellationTokenSource _cancellationTokenSource;
        private float _currentTime;
        private bool _canMove;

        public int Amount { get; private set; }

        private void OnEnable()
        {
            _cancellationTokenSource = new CancellationTokenSource();
        }

        private void OnDisable()
        {
            _cancellationTokenSource.Cancel();
        }

        public override void Destroy()
        {
            if (TryGetComponent(out PoolableObject poolableObject) == false)
            {
                Destroy(gameObject);

                return;
            }

            poolableObject.ReturnToPool();
            Hide();
        }

        public void SetAmount(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            Amount = amount;
        }

        public void SetCharacterWalletView(ICharacterWalletView characterWalletView) =>
            _characterWalletView = characterWalletView ??
                                   throw new ArgumentNullException(nameof(characterWalletView));

        public void SetCanMove() =>
            _canMove = true;

        private void Rotate() =>
            transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);

        private async void CollectAsync(CancellationToken cancellationToken)
        {
            try
            {
                await RotateCoinAsync(cancellationToken);
                await MoveToPlayerAsync(cancellationToken);
                await AddCoinsAsync(cancellationToken);

                Destroy();
            }
            catch (OperationCanceledException)
            {
            }
        }

        private async UniTask AddCoinsAsync(CancellationToken cancellationToken)
        {
            _canMove = false;

            await UniTask.Yield(cancellationToken);
        }

        private async UniTask RotateCoinAsync(CancellationToken cancellationToken)
        {
            while (_canMove == false)
            {
                Rotate();

                await UniTask.Yield(cancellationToken);
            }
        }

        private async UniTask MoveToPlayerAsync(CancellationToken cancellationToken)
        {
            var positionX = _characterWalletView.Position.x;
            var positionY = _characterWalletView.Position.y + _animationCurve.Evaluate(_currentTime);
            var positionZ = _characterWalletView.Position.z;
            var delta = _moveSpeed * Time.deltaTime;

            while (Vector3.Distance(
                       transform.position,
                       _characterWalletView.Position) > 1f)
            {
                _currentTime += Time.deltaTime;

                SetPosition(Vector3.MoveTowards(
                    transform.position,
                    new Vector3(positionX, positionY, positionZ),
                    delta));

                await UniTask.Yield(cancellationToken);
            }
        }
    }
}