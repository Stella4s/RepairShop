﻿using Microsoft.Ajax.Utilities;
using RepairShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RepairShop.CustomHtmlHelpers
{
    public static class TagExtension
    {

       /* {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            // Get the property name
            string name = ExpressionHelper.GetExpressionText(expression);
            // Get the property type
            Type type = metadata.ModelType;
            // Get the property value
            object value = metadata.Model;
       */

        public static HtmlString RepairOrderBackgroundStyle<TModel, TValue>(this HtmlHelper<TModel> helper, 
                                                                    Expression<Func<TModel, TValue>> expression, 
                                                                    object HtmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            //Type type = metadata.ModelType;
            //string name = ExpressionHelper.GetExpressionText(expression);
            RepairOrder value = metadata.Model as RepairOrder;
            IDictionary<string, object> attrs = new RouteValueDictionary(HtmlAttributes);
            string key = "Class";
            object AttributesValue;
            attrs.TryGetValue(key, out AttributesValue);

            if (value.RepairStatus.ToString() == "Awaiting" && DateTime.Now >= value.StartDate)
            {
                return new HtmlString(helper.Encode(String.Format("{0}", AttributesValue)));
            } else
            {
                return new HtmlString("");
            }

        }
    }
}