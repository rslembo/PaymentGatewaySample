using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PaymentGatewaySample.Domain.Services;
using System;

namespace PaymentGatewaySample.Filters
{
    public class MerchantAuthorize : ActionFilterAttribute
    {
        private IMerchantFinder _merchantFinder;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var mid = context.HttpContext.Request.Headers["MerchantId"];
            var mkey = context.HttpContext.Request.Headers["MerchantKey"];

            _merchantFinder = (IMerchantFinder)context.HttpContext.RequestServices.GetService(typeof(IMerchantFinder));

            if (!Guid.TryParse(mid, out var merchantId))
                context.Result = new UnauthorizedResult();

            var merchant = _merchantFinder.FindByIdAsync(merchantId).Result;

            if (merchant == null || !merchant.Key.Equals(mkey))
                context.Result = new UnauthorizedResult();

            base.OnActionExecuting(context);
        }
    }
}