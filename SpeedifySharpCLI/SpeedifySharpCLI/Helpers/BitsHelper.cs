namespace SpeedifySharpCLI.Helpers;

public static class BitsHelper
{
    const int DividerBits = 125000;
    const int DividerMbps = 8;

    public static double ToMbps(long bps)
    {
        return bps / DividerBits / DividerMbps;
    }
    public static double ToMbps(double bps)
    {
        return bps / DividerBits / DividerMbps;
    }
}
