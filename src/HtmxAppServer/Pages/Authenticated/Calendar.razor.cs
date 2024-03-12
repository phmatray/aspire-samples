namespace HtmxAppServer.Pages.Authenticated;

public class CalendarEndpoint
    : HtmxComponentEndpoint<Calendar, CalendarEndpoint.CalendarParameters>
{
    public override void Configure()
    {
        Get(RouteCalendar);
        AllowAnonymous();
    }

    public record CalendarParameters
        : HtmxComponentParameters;
}