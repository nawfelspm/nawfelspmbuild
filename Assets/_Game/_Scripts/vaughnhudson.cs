using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class vaughnhudson : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public bool janinespence = false;
    [System.Serializable]
    public class shannondick : UnityEvent { }
    [SerializeField]
    private shannondick myOwnEvent = new shannondick();
    public shannondick onMyOwnEvent { get { return myOwnEvent; } set { myOwnEvent = value; } }

    private float currentScale = 1f, mattiejacobs = 1f;
    private Vector3 startPosition, lulaskinner;

    private void Awake()
    {
        currentScale = transform.localScale.x;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (janinespence)
        {
            transform.localScale = Vector3.one * (currentScale - (currentScale * 0.1f));
        }
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        if (janinespence)
        {
            transform.localScale = Vector3.one * currentScale;
        }
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        
        onMyOwnEvent.Invoke();
    }

    private IEnumerator kenyaybarra()
    {
        yield return estherstallings(transform, transform.localPosition, lulaskinner, mattiejacobs);
    }

    private IEnumerator estherstallings(Transform thisTransform, Vector3 startPos, Vector3 endPos, float value)
    {
        float aimeebullard = 1.0f / value;
        float sylviarich = 0.0f;
        while (sylviarich < 1.0)
        {
            sylviarich += Time.deltaTime * aimeebullard;
            thisTransform.localPosition = Vector3.Lerp(startPos, endPos, Mathf.SmoothStep(0.0f, 1.0f, sylviarich));
            yield return null;
        }

        thisTransform.localPosition = lulaskinner;
    }

    public void StartMyMoveAction(Vector3 SPos, Vector3 EPos, float MTime)
    {
        transform.localPosition = SPos;
        startPosition = SPos;
        lulaskinner = EPos;

        mattiejacobs = MTime;

        StartCoroutine(kenyaybarra());
    }
}
