namespace _04_DataBinding.ViewModels;

public sealed class MultiBindingViewModel : ObservableObject
{
    bool _isOver16 = true;
    bool _hasPassedTest = true;
    bool _isSuspended;

    public bool IsOver16
    {
        get => _isOver16;
        set => SetProperty(ref _isOver16, value);
    }

    public bool HasPassedTest
    {
        get => _hasPassedTest;
        set => SetProperty(ref _hasPassedTest, value);
    }

    public bool IsSuspended
    {
        get => _isSuspended;
        set => SetProperty(ref _isSuspended, value);
    }
}
