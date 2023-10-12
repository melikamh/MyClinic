namespace MyClinic.Api.Contracts
{
    public sealed record SetEarliestAppointmentRequest(
        int doctorId,
        int pationId,
        DateTime date
    );
}
