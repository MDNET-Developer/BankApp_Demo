using BankApp.Web.Data.Context;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;

namespace BankApp.Web.TagHelpers
{
    [HtmlTargetElement("getaccountcount")]
    public class GetAccountCount:TagHelper
    {
        public int ApplicationUserConId { get; set; }
        private readonly BankContext _bankContext;

        public GetAccountCount(BankContext bankContext)
        {
            _bankContext = bankContext;
        }
        
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var accountCount = _bankContext.Accounts.Count(x => x.ApplicationUserId == ApplicationUserConId);
            var htmlcode = $"<span>{accountCount}</span>";
            output.Content.SetHtmlContent(htmlcode);
            base.Process(context, output);
        }
    }
}
