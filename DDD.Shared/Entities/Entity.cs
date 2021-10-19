﻿using System;

namespace DDD.Shared.Entities
{
    public abstract class Entity
    {
        public virtual long Id { get; protected set; }

        public override bool Equals(object obj)
        {
            if (obj is not Entity other)
                throw new InvalidOperationException("Object isn't Entity type");

            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return false;

            if (Id == default(int) || other.Id == default(int))
                return false;

            return Id == other.Id;
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
         
            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString()+Id).GetHashCode();
        }
    }
}
