namespace Sources.Utils.Extentions
{
    public static class PercentExtension
    {
        public static float ToPercent(this float value, float max)
        {
            float percent = max / 100f;
            int currentPercents = 0;
            float currentHealth = 0;

            while (currentHealth < value)
            {
                currentHealth += percent;
                currentPercents++;
            }

            return currentPercents;
        }
    }
}