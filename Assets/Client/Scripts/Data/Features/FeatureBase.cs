namespace Assets.Client.Scripts.Data.Features
{
    public abstract class FeatureBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public int Risk { get; set; }
        public string RiskName { get; set; }
    }
}
