public class RemapValues
{
    public static float Remap(float value, float originalMin, float originalMax, float newMin, float newMax)
    {
        return newMin + (value - originalMin) * (newMax - newMin) / (originalMax - originalMin);
    }
}
