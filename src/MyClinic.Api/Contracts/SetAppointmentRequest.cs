namespace MyClinic.Api.Contracts
{
    public sealed record SetAppointmentRequest(
        int doctorId,
        int pationId,
        DateTime date,
        TimeSpan StartTime
    );
}
