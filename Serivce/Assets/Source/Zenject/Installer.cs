using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Installer : MonoInstaller
{
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

        Container.Bind<UISwitcher<UIController>>().AsSingle().NonLazy();

        Container.Bind<PlayerView>().FromInstance(playerView).AsSingle();
        Container.Bind<PlayerController>().AsSingle().NonLazy();    

    }
}
