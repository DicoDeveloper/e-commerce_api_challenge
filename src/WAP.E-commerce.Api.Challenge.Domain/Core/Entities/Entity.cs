using System;

namespace WAP.E_commerce.Api.Challenge.Domain.Core.Entities
{
    public abstract class Entity
    {
        public Entity()
        {
            Active = true;
            Removed = false;
            CreatedAt = DateTime.Now;
        }

        public long Id { get; set; }
        public bool Active { get; private set; }
        public bool Removed { get; private set; }
        public DateTimeOffset CreatedAt { get; private set; }
        public DateTimeOffset? UpdatedAt { get; private set; }

        public void SetUpdatedAtToNow()
        {
            UpdatedAt = DateTime.Now;
        }

        public void ChangeStatus()
        {
            Active = !Active;
        }

        public void LogicalDelete()
        {
            Removed = true;
            Active = false;
        }

        public void ReactivateRemoved()
        {
            Removed = false;
            Active = true;
        }
    }
}