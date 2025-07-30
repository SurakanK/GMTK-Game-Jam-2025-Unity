public interface IUISelection
{
    void Selected();
    void UIUpdate();
    void Refresh();
    void SetData(object data, int index);
    void Clear();
    void Destroy();
    void ForceSelect();
}