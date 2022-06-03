using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class andrewhagan : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public bool auroraconnelly = false;
    [System.Serializable]
    public class charliemaurer : UnityEvent { }
    [SerializeField]
    private charliemaurer myOwnEvent = new charliemaurer();
    public charliemaurer onMyOwnEvent { get { return myOwnEvent; } set { myOwnEvent = value; } }

    private float currentScale = 1f, judithbutcher = 1f;
    private Vector3 startPosition, geraldineflores;

    private void Awake()
    {
        currentScale = transform.localScale.x;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (auroraconnelly)
        {
            transform.localScale = Vector3.one * (currentScale - (currentScale * 0.1f));
        }
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        if (auroraconnelly)
        {
            transform.localScale = Vector3.one * currentScale;
        }
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        
        onMyOwnEvent.Invoke();
    }

    private IEnumerator daynaortiz()
    {
        yield return estherstallings(transform, transform.localPosition, geraldineflores, judithbutcher);
    }

    private IEnumerator estherstallings(Transform thisTransform, Vector3 startPos, Vector3 endPos, float value)
    {
        float junemontoya = 1.0f / value;
        float nettiecuellar = 0.0f;
        while (nettiecuellar < 1.0)
        {
            nettiecuellar += Time.deltaTime * junemontoya;
            thisTransform.localPosition = Vector3.Lerp(startPos, endPos, Mathf.SmoothStep(0.0f, 1.0f, nettiecuellar));
            yield return null;
        }

        thisTransform.localPosition = geraldineflores;
    }

    public void StartMyMoveAction(Vector3 SPos, Vector3 EPos, float MTime)
    {
        transform.localPosition = SPos;
        startPosition = SPos;
        geraldineflores = EPos;

        judithbutcher = MTime;

        StartCoroutine(daynaortiz());
    }
}
