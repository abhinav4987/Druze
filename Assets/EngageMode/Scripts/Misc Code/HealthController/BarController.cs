public class BarController
{
    private float maxValue, currentValue = 0;

    public BarController(float maxValue)
    {
        this.maxValue = maxValue;
    }

    public void SetValue(float value)
    {
        currentValue = value;
    }

    public float GetNormalizedValue()
    {
        return currentValue / maxValue;
    }
    public float GetValue()
    {
        return currentValue;
    }

    public float GetMaxValue()
    {
        return maxValue;
    }
}
