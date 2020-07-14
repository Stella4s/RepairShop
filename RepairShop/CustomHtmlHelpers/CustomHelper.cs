using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Web.Mvc;
using RepairShop.Models;
using System.Web.Mvc.Html;
using System.Text;

namespace RepairShop.CustomHtmlHelpers
{
    public static class CustomHelper
    {
        //Example 1
        /*
        public static MvcHtmlString CustomDisplayFor <TModel, TProperty> (this HtmlHelper<TModel> htmlHelper, Expression<Func <TModel, TProperty>> expression)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            TagBuilder tb = new TagBuilder("input");
            tb.Attributes.Add("type", "text");
            tb.Attributes.Add("name", name);
            tb.Attributes.Add("value", metadata.Model as string);
            tb.Attributes.Add("style", "color:red");
            return new MvcHtmlString(tb.ToString());
        }
        
        //Example 2.
        /*
        public static IHtmlString ImageUpload(this HtmlHelper<BikeViewModel> htmlHelper, BikeViewModel viewModel)
        {
            var outerDiv = new TagBuilder("div");
            outerDiv.AddCssClass("pull-left upload-img-wrapper");
            var label = new TagBuilder("label");
            label.AddCssClass("upload-img");
            label.MergeAttribute("data-content", viewModel.ButtonText);

            var image = new TagBuilder("img");
            image.AddCssClass("img-responsive");
            image.MergeAttribute("src", viewModel.imageSource);
            image.MergeAttribute("width", "250");
            image.MergeAttribute("height", "250");

            var textbox = InputExtensions.TextBoxFor(htmlHelper, m => m.ImageName, new { type = "file", style = "display:none" });

            StringBuilder htmlBuilder = new StringBuilder();
            htmlBuilder.Append(label.ToString(TagRenderMode.StartTag));
            htmlBuilder.Append(image.ToString(TagRenderMode.Normal));
            htmlBuilder.Append(label.ToString(TagRenderMode.EndTag));
            htmlBuilder.Append(textbox.ToHtmlString());
            outerDiv.InnerHtml = htmlBuilder.ToString();
            var html = outerDiv.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(html);
        }*/

        //Attempt 1
        /*public static IHtmlString CustomDisplayForCustomer(this HtmlHelper<Customer> htmlHelper, Customer model)
        {
            TagBuilder outerDiv = new TagBuilder("div");
            var label1 = new TagBuilder("label");
            label1.AddCssClass("Form-control");
            var textbox1 = InputExtensions.TextBoxFor(htmlHelper, m => m.FirstName + " " + m.LastName);
            var textbox2 = InputExtensions.TextBoxFor(htmlHelper, m => m.Email);

            StringBuilder htmlBuilder = new StringBuilder();
            htmlBuilder.Append(textbox1.ToHtmlString());
            htmlBuilder.Append(textbox2.ToHtmlString());
            outerDiv.InnerHtml = htmlBuilder.ToString();

            return new MvcHtmlString(outerDiv.ToString());
        }*/
    }
}