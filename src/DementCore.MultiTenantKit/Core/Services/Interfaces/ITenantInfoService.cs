﻿using DementCore.MultiTenantKit.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DementCore.MultiTenantKit.Core.Services
{
    public interface ITenantInfoService<TTenant> where TTenant : ITenant
    {
        Task<TTenant> GetTenantInfoAsync(string tenantId);
    }
}
