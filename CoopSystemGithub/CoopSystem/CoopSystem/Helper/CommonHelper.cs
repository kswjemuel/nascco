using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoopSystemWebApp.Helper
{
    public static class CommonHelper
    {
        public static string ModelErrors(this System.Web.Mvc.ModelStateDictionary modelState)
        {
            return string.Join("<br>", modelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
        }

        public static string FormatDecimal(decimal number)
        {
            return number.ToString("#,##0.00");
        }

        public static decimal AdditionalPerChildCost = 300;
        public static decimal AnyOtherMemberAdditionalCostB1 = 700;
        public static decimal AnyOtherMemberAdditionalCostB2 = 1600;
        public static decimal AnyOtherMemberAdditionalCostB3 = 2400;
        public static decimal AnyOtherMemberAdditionalCostB4 = 3200;
        public static decimal AnyOtherMemberAdditionalCostB5 = 5000;
        public static decimal AnyOtherMemberAdditionalCostB6 = 8000;

        public static decimal GetAnyOtherMemberAdditionalCostB5(long option)
        {
            decimal amount = 0;
            switch (option)
            {
                case 1:
                    amount = AnyOtherMemberAdditionalCostB1;
                    break;
                case 2:
                    amount = AnyOtherMemberAdditionalCostB2;
                    break;
                case 3:
                    amount = AnyOtherMemberAdditionalCostB3;
                    break;
                case 4:
                    amount = AnyOtherMemberAdditionalCostB4;
                    break;
                case 5:
                    amount = AnyOtherMemberAdditionalCostB5;
                    break;
                case 6:
                    amount = AnyOtherMemberAdditionalCostB6;
                    break;
            }
            return amount;
        }

        public static double ConstantRate()
        {
            return 0.85;
        }
    }
}