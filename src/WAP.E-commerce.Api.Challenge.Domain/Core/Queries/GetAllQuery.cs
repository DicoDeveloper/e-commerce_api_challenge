namespace WAP.E_commerce.Api.Challenge.Domain.Core.Queries
{
    public abstract class GetAllQuery : Query
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}