﻿using FluentValidation.Results;
using Grpc.Core;
using System.Collections.Generic;
using System.Linq;

namespace Calzolari.Grpc.AspNetCore.FluentValidation.Internal
{
    internal static class MetadataExtensions
    {
        public static void AddValidationErrors(this Metadata metadata, IList<ValidationFailure> failures)
        {
            if (failures.Any())
            {
                metadata.Add(new Metadata.Entry("grpc-validation-errors-bin", failures.ToValidationTrailers().ToBytes()));
            }
        }
    }
}