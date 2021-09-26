namespace WAP.E_commerce.Api.Challenge.Domain.Core.Queries
{
    public abstract class GetByIdQuery : Query
    {
        public long Id { get; set; }
    }
}