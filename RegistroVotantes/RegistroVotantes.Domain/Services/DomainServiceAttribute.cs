﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroVotantes.Domain.Services
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class DomainServiceAttribute : Attribute
    {
    }
}
