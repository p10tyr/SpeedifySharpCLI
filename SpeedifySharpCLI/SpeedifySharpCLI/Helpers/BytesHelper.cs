namespace SpeedifySharpCLI.Helpers;

public static class BytesHelper
{
    const int DividerMB = 1000000;
    const int DividerMiB = 1024; //Binary notation

    /// <returns>MB</returns>
    public static double ToMegabyte(long bytes)
    {
        return bytes / DividerMB;
    }
    /// <returns>MB</returns>
    public static double ToMegabyte(double bytes)
    {
        return bytes / DividerMB;
    }
    
    /// <returns>MiB</returns>
    public static double ToMebibyte(long bytes)
    {
        return bytes / DividerMiB / DividerMiB;
    }

    /// <returns>MiB</returns>
    public static double ToMebibyte(double bytes)
    {
        return bytes / DividerMiB / DividerMiB;
    }
}
