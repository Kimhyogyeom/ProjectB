using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 씬 전환용 UI/애니메이션 매니저
/// </summary>
public class UITransition : MonoBehaviour
{
    [SerializeField] private Animator _doorAnim;    // 문 닫힘/열림 애니메이터
    [SerializeField] private Canvas _canvas;        // Slice 담고 있는 캔버스    

    public static UITransition Instance;

    private void Awake()
    {
        // 싱글톤 처리 : 중복 오브젝트 삭제
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // 씬 전환 시 유지
    }

    private void Start()
    {
        // Canvas를 항상 최상위로 렌더링 : 넉넉하게 10?
        _canvas.sortingOrder = 10;
    }

    /// <summary>
    /// 슬라이스 오픈
    /// </summary>
    public void OpenSlice()
    {
        _doorAnim.SetTrigger("Open");
    }

    /// <summary>
    /// 슬라이스 클로즈
    /// </summary>
    public void CloseSlice()
    {
        _doorAnim.SetTrigger("Close");
    }

    /// <summary>
    /// 슬라이드 Open Setting
    /// </summary>
    public void SetSliceOpen(string sceneName)
    {
        // 코루틴 실행
        StartCoroutine(TransitionCoroutine(sceneName));
    }

    /// <summary>
    /// 씬 전환 + 문 애니메이션 코루틴
    /// </summary>
    private IEnumerator TransitionCoroutine(string sceneName)
    {
        // 씬 비동기 로드
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // 씬 로드 완료될 때까지 기다리기
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // 씬 로드 완료되면 Open 애니메이션 전이 조건 실행
        _doorAnim.SetTrigger("Open");
    }
}
