namespace DISample.Others.Chain
{
    public class FirstDependency
    {
    }
    public class SeccondDependency
    {
        private readonly FirstDependency firstDependency;

        public SeccondDependency(FirstDependency firstDependency)
        {
            this.firstDependency = firstDependency;
        }
    }
    public class ThirdDependency
    {
        private readonly SeccondDependency seccond;

        public ThirdDependency(SeccondDependency seccond)
        {
            this.seccond = seccond;
        }
    }
}
