using ComponentUtilitys;

public class ImageInGame : ResizeBackgroundImage
{
    public virtual void ApplyBackground(object obj)
    {
        var bgInfo = (ImageInfo)obj;
        ApplySpriteResolution(bgInfo);
    }
        
}