namespace IdeologyPatch
{
    public static class Debug
    {
        public static void Log(object message)
        {
#if DEBUG
            Verse.Log.Message($"[{IdeologyPatchMod.PACKAGE_NAME}] {message}");
#endif
        }
    }
}
