namespace Lib.Data.Entity
{
    public class MasterDataModel : BaseImpactModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public int GroupId { get; set; } = 0;
    }
}