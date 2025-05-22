using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Installer : MonoInstaller
{
    private IPool<Bullet> _poolBullet;
    [SerializeField] private IntData startPool;
    [SerializeField] private Bullet bulletPref;
    [SerializeField] private TransformData transformData;
    [SerializeField] private AudioData audioData;
    [SerializeField] private PanelView panelView;
    [SerializeField] private OpenView openView;
    [SerializeField] private PlayerView playerView;
    public override void InstallBindings()
    {
        Container.Bind<IFadeService>().To<FadeService>().AsSingle().NonLazy();
        Container.Bind<ISoundPlayer>().To<SoundPlayer>().AsSingle().NonLazy();

        Container.Bind<PanelController>().AsSingle().NonLazy();
        Container.Bind<OpenController>().AsSingle().NonLazy();

        Container.Bind<AudioData>().FromInstance(audioData).AsSingle().NonLazy(); 

        Container.Bind<PanelView>().FromInstance(panelView).AsSingle().NonLazy();
        Container.Bind<OpenView>().FromInstance(openView).AsSingle().NonLazy();

        Container.Bind<TransformData>().FromInstance(transformData).AsSingle().NonLazy();

        Container.Bind<IntData>().FromInstance(startPool).AsSingle().NonLazy();
        Container.Bind<Bullet>().FromInstance(bulletPref).AsTransient();
        Container.BindFactory<ISoundPlayer,TransformData, Bullet, Bullet.BulletFactory>().FromComponentInNewPrefab(bulletPref)
         .AsSingle();
        Container.Bind<IPool<Bullet>>().To<Pool<Bullet>>().AsSingle().WithArguments(startPool.StartPool, bulletPref, transformData).NonLazy();
        Container.Bind<PlayerView>().FromInstance(playerView).AsSingle();
        Container.Bind<PlayerController>().AsSingle().NonLazy(); 
        
        Container.Bind<UISwitcher<UIController>>().AsSingle().NonLazy();
    }
}