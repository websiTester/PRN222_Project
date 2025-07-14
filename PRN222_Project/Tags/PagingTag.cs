
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Text;
using System.Xml.Linq;

namespace PRN222_Project.Tags
{
	[HtmlTargetElement("pagination")]
	public class PagingTag : TagHelper
	{
		public int PageNumber { get; set; }
		public int PageCount { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "div";
			output.Attributes.SetAttribute("class", "col-lg-12");

			var content = new StringBuilder();

			content.AppendLine("<div class=\"product__pagination\">");
			content.AppendLine("<nav aria-label=\"Page navigation example\">");
			content.AppendLine("<ul class=\"pagination\" style=\"display: inline-flex;\">");

			for (int i = 1; i <= PageCount; i++)
			{
				if (i == PageNumber)
				{
					content.AppendLine($@"
					<li class=""page-item active"">
						<button name=""page"" value=""{i}"" type=""submit"" class=""page-link active"">{i}</button>
					</li>");

				}
				else
				{
					content.AppendLine($@"
					<li class=""page-item"">
						<button name=""page"" value=""{i}"" type=""submit"" class=""page-link active"">{i}</button>
					</li>");

				}
			}

			content.AppendLine("</ul>");
			content.AppendLine("</nav>");
			content.AppendLine("</div>");

			output.Content.SetHtmlContent(content.ToString());
		}
	}
}
