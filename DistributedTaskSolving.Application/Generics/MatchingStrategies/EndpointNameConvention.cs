using System;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace DistributedTaskSolving.Application.Generics.MatchingStrategies
{
    [AttributeUsage(AttributeTargets.Class)]
    public class EndpointNameConvention : Attribute, IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            controller.ControllerName =
                controller.ControllerName.Remove(
                    controller.ControllerName.IndexOf("Endpoint", StringComparison.Ordinal)) + "s";
        }
    }
}