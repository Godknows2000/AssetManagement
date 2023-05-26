using Humanizer;
using Microsoft.AspNetCore.Html;
using AMS.Lib;
using System.Drawing;
using AMS.Data;

namespace AMS.Web;

public static class HtmlHelperExtension
{
    public static HtmlString ToStatusHtml(this bool value)
        => new($"<i class='fa fa-{(value ? "check-circle text-success" : "clock text-muted")}'></i>");
    public static HtmlString ToHtml(this bool value)
    {
        return value switch
        {
            true => new HtmlString($"<span class='badge bg-success'>ACTIVE</span>"),
            _ => new HtmlString($"<span class='badge bg-danger'>IN-ACTIVE</span>"),
        };
    }
    public static HtmlString AccountStatusHtml(this User user)
    {
        if (user.IsEmailConfirmed) return new HtmlString($"{user.IsActive.ToStatusHtml()} {(user.IsActive ? "ACTIVE" : "DEACTIVATED")}");
        else return new HtmlString("<i class='fa fa-user-clock text-secondary'></i> AWAITING ACTIVATION");
    }
    //public static HtmlString ToStatusHtml(this CreditProfile CreditProfile)
    //{
    //    if (CreditProfile.IsActive) return new HtmlString($"{CreditProfile.IsActive.ToStatusHtml()} {(CreditProfile.IsActive ? "ACTIVE" : "DEACTIVATED")}");
    //    else return new HtmlString("<i class='fa fa-user-clock text-secondary'></i> AWAITING ACTIVATION");
    //}
    //public static HtmlString Tenure(this Loan loan)
    //{
    //    if (loan.Tenure == 1) return new HtmlString($"{loan.Tenure} month");
    //    else return new HtmlString($"{loan.Tenure} months");
    //}
    public static bool IsNull(this PointF value)
    {
        return float.IsNaN(value.X) || float.IsNaN(value.Y);
    }
    //public static HtmlString Creditprofile(this CreditProfile CreditProfile)
    //{
    //    if (CreditProfile.IsActive) return new HtmlString($"{CreditProfile.IsActive.ToStatusHtml()} {(CreditProfile.IsActive ? "ACTIVE" : "DEACTIVATED")}");
    //    else return new HtmlString("<i class='fa fa-user-clock text-secondary'></i> AWAITING ACTIVATION");
    //}
    public static HtmlString ToHtml(this AssetStatus value)
    {
        return value switch
        {
            AssetStatus.REJECTED => new HtmlString($"<span class='badge bg-danger'>{value.Humanize()}</span>"),
            AssetStatus.AWAITING_APPROVAL => new HtmlString($"<span class='badge bg-warning'>{value.Humanize()}</span>"),
            AssetStatus.APPROVED => new HtmlString($"<span class='badge bg-success'>{value.Humanize()}</span>"),
            AssetStatus.CURRENT => new HtmlString($"<span class='badge bg-primary'>{value.Humanize()}</span>"),
            AssetStatus.CLOSED => new HtmlString($"<span class='badge bg-success'>{value.Humanize()}</span>"),
            AssetStatus.CANCELED => new HtmlString($"<span class='badge bg-danger'>{value.Humanize()}</span>"),
            _ => new HtmlString($"<span class='badge bg-light'>{value.Humanize()}</span>"),
        };
    }
}
