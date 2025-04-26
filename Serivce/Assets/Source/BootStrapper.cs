using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootStrapper : MonoBehaviour
{
    [SerializeField] private AudioClip closeClip;
    [SerializeField] private AudioClip openClip;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private CanvasGroup canvas;
    [SerializeField] private PanelView panel;
    [SerializeField] private OpenView openView;
    private PanelController _panelController;
    private OpenController _openController;
    private UISwitcher<UIController> _UIswitcher;
    private IServiceLocator _serviceLocator;
    private IFadeService _fadeService;
    private ISoundPlayer _soundPlayer;

    private void Start()
    {
        _panelController = new PanelController(panel);
        _openController = new OpenController(openView);
        _UIswitcher = new UISwitcher<UIController>(_openController, _panelController);
        _UIswitcher.ChangeState<OpenController>();
        _fadeService = new FadeService();
        _soundPlayer = new SoundPlayer(audioSource,openClip,closeClip);
        _serviceLocator.AddService(_fadeService);
        _serviceLocator.AddService(_soundPlayer);
    }
}
