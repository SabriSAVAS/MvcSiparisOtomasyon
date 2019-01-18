﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiparisEnt.WebUI.Infrastructure.Alerts
{
    public static class AlertExtensions
    {
        private const string Alerts = "_Alerts";

        public static  List<Alert> GetAlerts(this TempDataDictionary tempData)
        {
            if (!tempData.ContainsKey(Alerts))
            {
                tempData[Alerts]=new List<Alert>();
            }

            return (List<Alert>)tempData[Alerts];
        }

        public static ActionResult WiActionResult(this ActionResult result, string message)
        {
            return  new AlertDecoratorResult(result, "success", message);
        }
        public static ActionResult WithInfo(this ActionResult result, string message)
        {
            return new AlertDecoratorResult(result, "info", message);
        }

        public static ActionResult WithWarning(this ActionResult result, string message)
        {
            return new AlertDecoratorResult(result, "warning", message);
        }

        public static ActionResult WithError(this ActionResult result, string message)
        {
            return new AlertDecoratorResult(result, "danger", message);
        }
    }
}