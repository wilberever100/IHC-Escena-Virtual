using UnityEngine ;
using UnityEngine.UI ;
using DG.Tweening ;

public class SwitchToggle : MonoBehaviour {
   [SerializeField] RectTransform uiHandleRectTransform ;
   [SerializeField] Color backgroundActiveColor ;
   [SerializeField] Color handleActiveColor ;
   //[SerializeField] Color backgroundDefaultColor;
   //[SerializeField] Color handleDefaultColor;
   Image backgroundImage, handleImage ;
    Color backgroundDefaultColor, handleDefaultColor;



   Toggle toggle ;

   Vector2 handlePosition ;
    void Start()
    {
        
    }
    void Awake ( ) {
      toggle = GetComponent <Toggle> ( ) ;

      handlePosition = uiHandleRectTransform.anchoredPosition ;

      backgroundImage = uiHandleRectTransform.parent.GetComponent <Image> ( ) ;
      handleImage = uiHandleRectTransform.GetComponent <Image> ( ) ;
        backgroundDefaultColor = backgroundImage.color ;
        handleDefaultColor = handleImage.color ;

        //set alpha to visible
        backgroundActiveColor.a = 1f;
        handleActiveColor.a = 1f;

        toggle.onValueChanged.AddListener (OnSwitch) ;

      if (toggle.isOn)
         OnSwitch (true) ;
   }

   void OnSwitch (bool on) {
      //uiHandleRectTransform.anchoredPosition = on ? handlePosition * -1 : handlePosition ; // no anim
      uiHandleRectTransform.DOAnchorPos (on ? handlePosition * -1 : handlePosition, .4f).SetEase (Ease.InOutBack) ;

      //backgroundImage.color = on ? backgroundActiveColor : backgroundDefaultColor ; // no anim
      backgroundImage.DOColor (on ? backgroundActiveColor : backgroundDefaultColor, .6f) ;

      //handleImage.color = on ? handleActiveColor : handleDefaultColor ; // no anim
      handleImage.DOColor (on ? handleActiveColor : handleDefaultColor, .4f) ;

        CamSwitch Switching;
        if (on)
        {
            GameObject.Find("TextEdit").GetComponent<Text>().text="Presentador";    //change name
            GameObject.Find("CamSwitcher").GetComponent<CamSwitch>().configPresenter() ;
        }
        else
        {
            GameObject.Find("TextEdit").GetComponent<Text>().text = "Editor";
            GameObject.Find("CamSwitcher").GetComponent<CamSwitch>().configEditor();
        }
   }

   void OnDestroy ( ) {
      toggle.onValueChanged.RemoveListener (OnSwitch) ;
   }
}
