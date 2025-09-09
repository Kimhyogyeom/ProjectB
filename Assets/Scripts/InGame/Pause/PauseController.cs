using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _noButton;
    [SerializeField] private CanvasGroup[] _canvasImages; // 여러 UI
    [SerializeField] private GameObject _pauseObj;

    [SerializeField] private float _fadeDuration = 1.0f; // 서서히 사라지는 시간

    void Awake()
    {
        _pauseButton.onClick.AddListener(OnClickPauseButton);
        _noButton.onClick.AddListener(OnClickNoButton);
    }

    public void OnClickPauseButton()
    {
        StartCoroutine(CanvasUIHideCoroutine());
    }
    public void OnClickNoButton()
    {
        StartCoroutine(CanvasUIShowCoroutine());
    }
    IEnumerator CanvasUIHideCoroutine()
    {
        Time.timeScale = 0f;

        float time = 0f;

        while (time < _fadeDuration)
        {
            time += Time.unscaledDeltaTime;
            float alpha = Mathf.Lerp(1f, 0f, time / _fadeDuration);

            // 모든 CanvasGroup에 동일하게 적용
            foreach (var canvas in _canvasImages)
            {
                if (canvas != null)
                {
                    canvas.alpha = alpha;
                }
            }

            yield return null;
        }

        // 완전히 사라지면 비활성화 패널 띄움
        _pauseObj.SetActive(true);
    }
    IEnumerator CanvasUIShowCoroutine()
    {
        _pauseObj.SetActive(false);
        Time.timeScale = 1;
        float time = 0f;

        while (time < _fadeDuration)
        {
            time += Time.unscaledDeltaTime;
            float alpha = Mathf.Lerp(0f, 1f, time / _fadeDuration);

            // 모든 CanvasGroup에 동일하게 적용
            foreach (var canvas in _canvasImages)
            {
                if (canvas != null)
                {
                    canvas.alpha = alpha;
                }
            }

            yield return null;
        }
    }
}
