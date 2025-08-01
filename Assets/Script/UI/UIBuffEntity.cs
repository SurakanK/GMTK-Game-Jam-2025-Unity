
public class UIBuffEntity : UISelection<BaseBuff>
{
    public override void UIUpdate()
    {
        base.UIUpdate();
        SetImage(Data.icon);
    }

    public void ResetUI()
    {
        SetImage(null);
    }
}