using UnityEngine;
using Zenject;

public class MovementInitializator : MonoInstaller
{
    [SerializeField] PlayerMovement _playerMovement;

    public override void InstallBindings()
    {
        Container.Bind<PlayerMovement>().FromInstance(_playerMovement).AsSingle().NonLazy();
    }
}