using UnityEngine;
using DG.Tweening;

public class MainMenuAnimator : MonoBehaviour
{
    [Header("UI Elements")]
    public RectTransform gameTitle;
    public RectTransform playButton;
    public RectTransform settingsButton;
    public RectTransform levelPanel;
    public RectTransform settingsPanel;
    public GameObject gamePanel; // 🔹 New: Game panel reference

    [Header("Animation Durations")]
    public float titleDropTime = 1f;
    public float buttonPopTime = 0.8f;
    public float panelSlideTime = 0.6f;

    private Vector2 titleTargetPos;
    private Vector2 playButtonTargetScale;
    private Vector2 settingsTargetPos;
    private Vector2 levelPanelTargetPos;
    private Vector2 settingsPanelTargetPos;

    private Vector2 levelPanelOffscreenPos;
    private Vector2 settingsPanelOffscreenPos;

    void Start()
    {
        // Save initial layout positions
        titleTargetPos = gameTitle.anchoredPosition;
        playButtonTargetScale = Vector2.one;
        settingsTargetPos = settingsButton.anchoredPosition;
        levelPanelTargetPos = levelPanel.anchoredPosition;
        settingsPanelTargetPos = settingsPanel.anchoredPosition;

        // Offscreen slide targets
        levelPanelOffscreenPos = new Vector2(0, -Screen.height);
        settingsPanelOffscreenPos = new Vector2(Screen.width, 0);

        // Hide panels and move offscreen
        levelPanel.gameObject.SetActive(false);
        settingsPanel.gameObject.SetActive(false);
        //gamePanel.SetActive(false);

        // Setup intro animation positions
        gameTitle.anchoredPosition += new Vector2(0, 300);
        playButton.localScale = Vector3.zero;
        settingsButton.anchoredPosition += new Vector2(-400, 0);

        AnimateMainMenu();
    }

    void AnimateMainMenu()
    {
        gameTitle.DOAnchorPos(titleTargetPos, titleDropTime).SetEase(Ease.OutBounce);
        playButton.DOScale(playButtonTargetScale, buttonPopTime).SetEase(Ease.OutBack).SetDelay(0.3f);
        settingsButton.DOAnchorPos(settingsTargetPos, buttonPopTime).SetEase(Ease.OutBack).SetDelay(0.6f);
    }

    public void OnPlayButtonClicked()
    {
        levelPanel.gameObject.SetActive(true);
        levelPanel.anchoredPosition = levelPanelOffscreenPos;
        levelPanel.DOAnchorPos(levelPanelTargetPos, panelSlideTime).SetEase(Ease.OutExpo);
    }

    public void OnSettingsButtonClicked()
    {
        settingsPanel.gameObject.SetActive(true);
        settingsPanel.anchoredPosition = settingsPanelOffscreenPos;
        settingsPanel.DOAnchorPos(settingsPanelTargetPos, panelSlideTime).SetEase(Ease.OutExpo);
    }

    public void CloseLevelPanel()
    {
        levelPanel.DOAnchorPos(levelPanelOffscreenPos, panelSlideTime)
            .SetEase(Ease.InBack)
            .OnComplete(() => {
                levelPanel.gameObject.SetActive(false);
                gamePanel.SetActive(true); // 🔹 Activate GamePanel after level panel hides
            });
    }

    public void CloseSettingsPanel()
    {
        settingsPanel.DOAnchorPos(settingsPanelOffscreenPos, panelSlideTime)
            .SetEase(Ease.InBack)
            .OnComplete(() => settingsPanel.gameObject.SetActive(false));
    }
}