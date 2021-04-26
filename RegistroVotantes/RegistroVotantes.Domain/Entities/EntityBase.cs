﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroVotantes.Domain.Entities
{
    public class EntityBase<T> : DomainEntity, IEntityBase<T>
    {
        public virtual T Id { get; set; }
    }
}
