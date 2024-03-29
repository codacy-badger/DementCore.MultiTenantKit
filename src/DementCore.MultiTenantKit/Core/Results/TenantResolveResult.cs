﻿using DementCore.MultiTenantKit.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DementCore.MultiTenantKit.Core
{
    public class TenantResolveResult
    {
        #region Public Constructors

        /// <summary>
        /// Creates a TenantResolveResult that indicates a tenant resolution has been performed.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="resolvedType"></param>
        public TenantResolveResult(string value, ResolutionType resolvedType)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Value = value;
                ResolutionResult = ResolutionResult.NotFound;
                ResolutionType = ResolutionType.Nothing;
                ErrorMessage = "";
            }
            else
            {
                Value = value;
                ResolutionResult = ResolutionResult.Success;
                ResolutionType = (resolvedType == ResolutionType.Nothing) ? ResolutionType.TenantName : resolvedType;
                ErrorMessage = "";
            }
        }

        /// <summary>
        /// Creates a TenantResolveResult that indicates and error in tenant's resolution
        /// </summary>
        /// <param name="exception"></param>
        public TenantResolveResult(Exception exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("You must specify an exception.");
            }

            Value = "";
            ResolutionResult = ResolutionResult.Error;
            ResolutionType = ResolutionType.Nothing;
            ErrorMessage = exception?.Message ?? "";
        }

        /// <summary>
        /// Creates a TenantResolveResult that indicates and error in tenant's resolution
        /// </summary>
        /// <param name="errorMessage"></param>
        public TenantResolveResult(string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
            {
                throw new ArgumentNullException("You must specify a error message ");
            }

            Value = "";
            ResolutionResult = ResolutionResult.Error;
            ResolutionType = ResolutionType.Nothing;
            ErrorMessage = errorMessage;
        }

        #endregion

        #region Private Constructors

        /// <summary>
        /// Create a TenantResolveResult that indicates that the tenant's resolution result of this request.
        /// </summary>
        /// <param name="resolutionResult"></param>
        private TenantResolveResult(ResolutionResult resolutionResult)
        {
            Value = "";
            ResolutionType = ResolutionType.Nothing;
            ResolutionResult = resolutionResult;
            ErrorMessage = "";
        }

        #endregion

        #region Public Static Properties

        /// <summary>
        /// Indicates that the tenant's resolution does not apply in this request.
        /// </summary>
        public static TenantResolveResult NotApply { get; } = new TenantResolveResult(ResolutionResult.NotApply);

        /// <summary>
        /// Indicates that the tenant's is not found.
        /// </summary>
        public static TenantResolveResult NotFound { get; } = new TenantResolveResult(ResolutionResult.NotFound);

        #endregion

        #region Public Properties

        public string Value { get; }

        public string ErrorMessage { get; }

        public ResolutionResult ResolutionResult { get; }

        public ResolutionType ResolutionType { get; }

        #endregion
    }
}
