namespace PersonalFinanceManager.Domain.ValueObjects;

public readonly struct DateRange
{
    public DateOnly Start { get; }
    public DateOnly End { get; }

    public DateRange(DateOnly start, DateOnly end)
    {
        if (end < start)
            throw new ArgumentException($"End date ({end}) cannot be earlier than start date ({start}).");

        Start = start;
        End = end;
    }

    public bool Contains(DateOnly date) => date >= Start && date <= End;

    public int TotalDays() => End.DayNumber - Start.DayNumber + 1;

    public override string ToString() => $"{Start:yyyy-MM-dd} — {End:yyyy-MM-dd}";

    public static DateRange ForMonth(int year, int month)
    {
        var start = new DateOnly(year, month, 1);
        var end = new DateOnly(year, month, DateTime.DaysInMonth(year, month));
        return new DateRange(start, end);
    }

    public static DateRange ForToday()
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        return new DateRange(today, today);
    }
}