namespace tutorial03;

public class Camera : Equipment
{
    public int Megapixels { get; private set; }
    public bool HasOpticalZoom { get; private set; }
    public string LensType { get; private set; }
    
    public Camera() : base()
    {
        Megapixels = 0;
        HasOpticalZoom = false;
        LensType = "Unknown lens type";
    }

    public Camera(string name, bool isAvailable, int megapixels, bool hasOpticalZoom, string lensType) : base(name,
        isAvailable)
    {
        Megapixels = megapixels;
        HasOpticalZoom = hasOpticalZoom;
        LensType = lensType;
    }
}