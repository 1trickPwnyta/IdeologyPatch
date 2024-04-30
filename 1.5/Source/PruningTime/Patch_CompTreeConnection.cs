namespace IdeologyPatch.PruningTime
{
    // Patched manually in mod constructor
    public static class Patch_CompTreeConnection_ctor
    {
        public static void Postfix(ref float ___TimeBetweenAutoPruning)
        {
            ___TimeBetweenAutoPruning = 0f;
        }
    }
}
