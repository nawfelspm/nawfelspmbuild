using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class vanmoran : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public bool ashleylawson = false;
    [System.Serializable]
    public class samuelcunningham : UnityEvent { }
    [SerializeField]
    private samuelcunningham myOwnEvent = new samuelcunningham();
    public samuelcunningham onMyOwnEvent { get { return myOwnEvent; } set { myOwnEvent = value; } }

    private float currentScale = 1f, krystalcornelius = 1f;
    private Vector3 startPosition, janellcaudill;

    private void Awake()
    {
        currentScale = transform.localScale.x;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (ashleylawson)
        {
            transform.localScale = Vector3.one * (currentScale - (currentScale * 0.1f));
        }
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        if (ashleylawson)
        {
            transform.localScale = Vector3.one * currentScale;
        }
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        
        onMyOwnEvent.Invoke();
    }

    private IEnumerator francesnelson()
    {
        yield return estherstallings(transform, transform.localPosition, janellcaudill, krystalcornelius);
    }

    private IEnumerator estherstallings(Transform thisTransform, Vector3 startPos, Vector3 endPos, float value)
    {
        float winifredlandis = 1.0f / value;
        float judiburke = 0.0f;
        while (judiburke < 1.0)
        {
            judiburke += Time.deltaTime * winifredlandis;
            thisTransform.localPosition = Vector3.Lerp(startPos, endPos, Mathf.SmoothStep(0.0f, 1.0f, judiburke));
            yield return null;
        }

        thisTransform.localPosition = janellcaudill;
    }

    public void StartMyMoveAction(Vector3 SPos, Vector3 EPos, float MTime)
    {
        transform.localPosition = SPos;
        startPosition = SPos;
        janellcaudill = EPos;

        krystalcornelius = MTime;

        StartCoroutine(francesnelson());
    }
}
