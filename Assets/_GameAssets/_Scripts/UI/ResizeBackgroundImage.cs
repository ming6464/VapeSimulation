using System;
using UnityEngine;
using UnityEngine.UI;
using VInspector;

namespace ComponentUtilitys
{
    public class ResizeBackgroundImage : MonoBehaviour
    {
        [Foldout("Info")]
        [SerializeField,Variants(0,1)]
        protected int _match = 1;
        [SerializeField]
        protected Vector2 _resolutionReference = new (1080,1920);
        [Foldout("Reference")]
        [SerializeField]
        protected Image _image;
        [Foldout("Data")]
        [SerializeField]
        protected ImageInfo _imageInfo;
        [EndFoldout]
        
        private Vector2 _screenCalculate;
        
        //
        protected RectTransform _imageRtf;

        protected virtual void Awake()
        {
            if (!_image)
            {
                _image = GetComponent<Image>();
            }
            
            if(!_image)
                return;
            _imageRtf = _image.rectTransform;
            CalculateScreenSize();
            ApplySpriteResolution(_imageInfo);
            
        }
        

        private void CalculateScreenSize()
        {
            var screenHeightCalculate = 0f;
            var screenWidthCalculate  = 0f;
            
            if (_match - 1 == 0)
            {
                screenHeightCalculate = _resolutionReference.y;
                var ratio = screenHeightCalculate / Screen.height;
                screenWidthCalculate = Screen.width * ratio;
            }
            else
            {
                screenWidthCalculate = _resolutionReference.x;
                var ratio = screenWidthCalculate / Screen.width;
                screenHeightCalculate = Screen.height * ratio;
            }
            _screenCalculate = new Vector2(screenWidthCalculate, screenHeightCalculate);
        }

        protected virtual void ApplySpriteResolution(ImageInfo imageInfo)
        {
            if(!_image)
                return;
            var width                 = 0f;
            var height                = 0f;
            var screenHeightCalculate = _screenCalculate.y;
            var screenWidthCalculate  = _screenCalculate.x;
            
            var resolution = imageInfo.resolution;
            var sprite     = imageInfo.sprite;
            
            var subtractW = screenWidthCalculate - resolution.x;
            var subtractH = screenHeightCalculate - resolution.y;
    
            if (subtractW > subtractH)
            {
                width = screenWidthCalculate;
                var ratio = width / resolution.x;
                height = resolution.y * ratio;
            }
            else
            {
                height = screenHeightCalculate;
                var ratio = height / resolution.y;
                width = resolution.x * ratio;
            }
    
            _imageRtf.sizeDelta = new Vector2(width, height);
            _image.sprite       = sprite;
        }
    }

    [Serializable]
    public struct ImageInfo
    {
        public Vector2 resolution;
        public Sprite sprite;
    }
    
}