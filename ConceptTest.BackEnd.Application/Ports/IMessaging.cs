namespace ConceptTest.BackEnd.Application.Ports;

public interface IMessaging
{
    Task SendMessageAsync(object o, string queue);
}