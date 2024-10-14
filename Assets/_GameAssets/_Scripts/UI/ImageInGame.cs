using ComponentUtilitys;

public class ImageInGame : ResizeBackgroundImage
{
    protected virtual void ApplyBackground(object obj)
    {
        var bgInfo = (ImageInfo)obj;
        ApplySpriteResolution(bgInfo);
    }
        
}