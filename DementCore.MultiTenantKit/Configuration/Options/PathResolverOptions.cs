﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DementCore.MultiTenantKit.Configuration.Options
{
    public class PathResolverOptions
    {
        /// <summary>
        /// Determines the name of the segment to search in the path and extract the tenant's Slug
        /// </summary>
        public string RouteSegmentName { get; set; }
    }
}
